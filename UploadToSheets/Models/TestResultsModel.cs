using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public class TestResultsModel
    {
        public TestResultsModel(int testResultId, string dbId, string status, decimal? cpuMaxTemp, decimal? gpuMaxTemp, int? errorCount, int? wheaErrorCount, string? batteryLife)
        {
            this.TestResultId = testResultId;
            this.DbId = dbId;
            this.Status = status;
            this.CPUMaxTemp = cpuMaxTemp;
            this.GPUMaxTemp = gpuMaxTemp;
            this.ErrorCount = errorCount;
            this.WheaErrorCount = wheaErrorCount;
            this.BatteryLife = batteryLife;
        }

        public int TestResultId { get; }
        public string DbId { get; }
        public string Status { get; }
        public decimal? CPUMaxTemp { get; }
        public decimal? GPUMaxTemp { get; }
        public int? ErrorCount { get; }
        public int? WheaErrorCount { get; }
        public string? BatteryLife { get; }
    }

}
