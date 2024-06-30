using Google.Apis.Sheets.v4;
using GoogleSheetsAPI;
using System.Collections.Generic;
using System.Timers;
using UploadToSheets.DTOS;
using UploadToSheets.Models;
using UploadToSheets.Services.ManifestTableService;
namespace UploadToSheets
{
    public partial class Upload : Form
    {

        private static System.Timers.Timer hourlyTimer;
        public Upload()
        {
            InitializeComponent();
            SetHourlyTimer();
        }
        private void SetHourlyTimer()
        {
            // Create a timer with a one-hour interval.
            hourlyTimer = new System.Timers.Timer(3600000); // 3600000 milliseconds = 1 hour

            // Hook up the Elapsed event for the timer.
            hourlyTimer.Elapsed += OnTimedEvent;
            hourlyTimer.AutoReset = true;
            hourlyTimer.Enabled = true;

            // To start the first event at the top of the next hour
            DateTime now = DateTime.Now;
            DateTime nextHour = now.AddHours(1).AddMinutes(-now.Minute).AddSeconds(-now.Second).AddMilliseconds(-now.Millisecond);
            double firstInterval = (nextHour - now).TotalMilliseconds;

            System.Timers.Timer firstTimer = new System.Timers.Timer(firstInterval);
            firstTimer.Elapsed += (sender, e) =>
            {
                firstTimer.Dispose();
                OnTimedEvent(sender, e);
                hourlyTimer.Start();
            };
            firstTimer.AutoReset = false;
            firstTimer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                UploadSequance();

                
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
               
            }
        }

        private static void UploadSequance()
        {
            UploadModel uploadModel = new UploadModel();
            uploadModel.UploadManifest();
            uploadModel.UploadHistory();
            uploadModel.UploadQCData();
            uploadModel.UploadTestResults();
            uploadModel.UploadWindowsKey();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploadSequance();
            richTextBox1.AppendText($"Uploaded Manually");
        }
    }
}
