using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using UploadToSheets.Models;

namespace GoogleSheetsAPI
{
    public class GoogleSheetsService
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        private readonly SheetsService _sheetsService;
        private readonly string _spreadsheetId;

        public GoogleSheetsService(string spreadsheetId)
        {
            _spreadsheetId = spreadsheetId;

            UserCredential credential;
            using (var stream =
                new FileStream("cred.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.

                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

            }

            // Create Google Sheets API service.
            _sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public void UploadData(string sheetName, IList<IList<object>> values)
        {
            var range = $"{sheetName}!A1";
            var valueRange = new ValueRange
            {
                Values = values
            };

            var appendRequest = _sheetsService.Spreadsheets.Values.Append(valueRange, _spreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();
        }

        public void AppendDataToBottom(string sheetName, IList<IList<object>> values)
        {
            var range = $"{sheetName}!A:A";
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute();

            int lastRow = response.Values != null ? response.Values.Count + 1 : 1;
            range = $"{sheetName}!A{lastRow}";

            var valueRange = new ValueRange
            {
                Values = values
            };

            var appendRequest = _sheetsService.Spreadsheets.Values.Append(valueRange, _spreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendResponse = appendRequest.Execute();
        }

        public IList<IList<object>> ReadData(string sheetName,string startColumn="A",int startRow=1, string endColumn = "Z")
        {
            var range = $"{sheetName}!{startColumn}{startRow}:{endColumn}"; // Adjust the range as needed
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute();
            return response.Values;
        }
        public async Task<IList<IList<object>>> ConvertToSheetData(IEnumerable<object> data)
        {
            var sheetData = new List<IList<object>>();


            foreach (var model in data)
            {
                var row = new List<object>();
                foreach (var property in model.GetType().GetProperties())
                {
                    var value = property.GetValue(model)??"Null";
                    row.Add(value);
                }
                sheetData.Add(row);
            }

            return await Task.FromResult<IList<IList<object>>>(sheetData);
        }
        public void ClearSheet( string sheetName)
        {
            var requestBody = new ClearValuesRequest();
            var clearRequest = _sheetsService.Spreadsheets.Values.Clear(requestBody, _spreadsheetId, sheetName);
            var response = clearRequest.Execute();

            Console.WriteLine("Sheet cleared: " + response.ClearedRange);
        }
        public void ClearSheetButKeepHeaders(string sheetName)
        {
            int totalRows = GetTotalRows(sheetName);

            if (totalRows <= 1)
            {
                Console.WriteLine("No rows to clear besides the header.");
                return;
            }
            var range = $"{sheetName}!2:{totalRows}";
            var requestBody = new ClearValuesRequest();
            var clearRequest = _sheetsService.Spreadsheets.Values.Clear(requestBody, _spreadsheetId, range);
            var response = clearRequest.Execute();
        }

        private int GetTotalRows(string sheetName)
        {
            var spreadsheet = _sheetsService.Spreadsheets.Get(_spreadsheetId).Execute();
            var sheet = spreadsheet.Sheets.FirstOrDefault(s => s.Properties.Title == sheetName);

            if (sheet == null)
            {
                throw new Exception($"Sheet '{sheetName}' not found.");
            }

            var sheetId = (int)sheet.Properties.SheetId;

            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, sheetName);
            var response = request.Execute();

            return response.Values != null ? response.Values.Count : 0;
        }
    }
}

