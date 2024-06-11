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

        public IList<IList<object>> ReadData(string sheetName)
        {
            var range = $"{sheetName}!A1:Z1000"; // Adjust the range as needed
            var request = _sheetsService.Spreadsheets.Values.Get(_spreadsheetId, range);
            var response = request.Execute();
            return response.Values;
        }
        public async Task<IList<IList<object>>> ConvertToSheetData(IEnumerable<ManifestModel> manifestModels)
        {
            var sheetData = new List<IList<object>>();

            // Adding headers if necessary
            sheetData.Add(new List<object> { "Prebuild", "PrebuildSku", "OrderNumber", "OrderSku" });

            foreach (var model in manifestModels)
            {
                var row = new List<object> { model.prebuildId, model.prebuildSKU, model.orderId, model.orderSku };
                sheetData.Add(row);
            }

            return sheetData;
        }
    }
}

