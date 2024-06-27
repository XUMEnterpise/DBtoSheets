﻿using GoogleSheetsAPI;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.Services.HistoryService;
using UploadToSheets.Services.ManifestTableService;

namespace UploadToSheets.Models
{
    public class UploadModel
    {
       private readonly GoogleSheetsService sheetsService = new GoogleSheetsService("1aw5Ir8ppS0AdUVfn0xFvV2v0Tk66txCDv9i48CQXmKY");

       public async void UploadManifest()
       {
            IDatabaseManifestTable databaseManifestTable = new DatabaseManifestTable();
            var data = Task.Run(() => sheetsService.ConvertToSheetData(databaseManifestTable.GetManifestModels().Result));
            var table = await data;
            
            await Task.Run(() => UploadDataClear("Manifest", "A", 2, "D", table));
       }
       public async void UploadHistory()
        {
            IDatabaseToHistory databaseHistoryTable = new DatabaseToHistoryService();
            var data = Task.Run(() => sheetsService.ConvertToSheetData(databaseHistoryTable.GetHistoryModels().Result));
            var table = await data;
            await Task.Run(() => UploadDataClear("History", "A", 2, "L", table));
       }
        private async void UploadData(string sheetName,string columnStart, int rowStart, string columnEnd, IList<IList<object>> table)
        {
            var sheet = sheetsService.ReadData(sheetName, columnStart, rowStart, columnEnd);
            if (sheet.IsNullOrEmpty())
            {
                sheetsService.UploadData(sheetName, table);
                return;
            }
            var newValues = FindNewValues(sheet, table, 0);
            sheetsService.UploadData(sheetName, newValues);
        }
        private async void UploadDataClear(string sheetName, string columnStart, int rowStart, string columnEnd, IList<IList<object>> table)
        {
            var sheet = sheetsService.ReadData(sheetName, columnStart, rowStart, columnEnd);
            sheetsService.ClearSheet(sheetName);
            sheetsService.UploadData(sheetName, table);
        }
        private static IList<IList<object>> FindNewValues(IList<IList<object>> list1, IList<IList<object>> list2,int column)
       {
            var newValues = new List<IList<object>>();

            var set1 = new HashSet<string>(list1
            .Where(innerlist => innerlist.Count>0 && innerlist[column] !=null)
            .Select(innerlist => innerlist[column].ToString() ?? ""));

            var set2 = new HashSet<string>(list2
            .Where(innerlist => innerlist.Count > 0 && innerlist[column] != null)
            .Select(innerlist => innerlist[column].ToString() ?? ""));

            foreach (var item in set2)
            {
                if (!set1.Contains(item))
                {
                    var newItem = item.Split(',').Select(s => (object)s).ToList();
                    newValues.Add(newItem);
                }
            }
            return newValues;
       }
    }
}
