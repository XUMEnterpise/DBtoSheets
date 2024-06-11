using Google.Apis.Sheets.v4;
using GoogleSheetsAPI;
using System.Collections.Generic;
using UploadToSheets.DTOS;
using UploadToSheets.Models;
using UploadToSheets.Services.ManifestTableService;
namespace UploadToSheets
{
    public partial class Upload : Form
    {
        GoogleSheetsService sheetsService = new GoogleSheetsService("1aw5Ir8ppS0AdUVfn0xFvV2v0Tk66txCDv9i48CQXmKY");
        public Upload()
        {
            InitializeComponent();
            RichTextBox richTextBox = new RichTextBox()
            {
                Width = 300,
                Height = 300,
                ReadOnly = true,
            };
            

            this.Controls.Add(richTextBox);
            
        }
        override protected async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await UploadToSheets();
        }
        private async Task<IList<IList<object>>> getManifestTable(IEnumerable<ManifestModel> objects)
        {
            return await sheetsService.ConvertToSheetData(objects);
        }
        public async Task UploadToSheets()
        {
            IDatabaseManifestTable databaseManifestTable = new DatabaseManifestTable();
            var data = await getManifestTable(databaseManifestTable.GetManifestModels().Result);
            sheetsService.UploadData("HistoryTable", data);
        } 

            
    }
}
