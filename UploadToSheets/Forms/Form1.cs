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
        private readonly UploadModel uploadModel = new UploadModel();
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
            uploadModel.UploadManifest();
            uploadModel.UploadHistory();
        }
        

            
    }
}
