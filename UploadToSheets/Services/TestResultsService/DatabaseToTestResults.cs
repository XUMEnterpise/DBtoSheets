using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services.TestResultsService
{
    public class DatabaseToTestResults : ITestResultsToModel
    {
        public async Task<IEnumerable<TestResultsModel>> GetTestResultsModel()
        {
            using (ApplicationDbContext dBContext = new ApplicationDbContext())
            {
                IEnumerable<TestResult> qcresults = await dBContext.TestResults.ToListAsync();
                return qcresults.Select(r => ToQcResultsModel(r));
            }
        }

        private TestResultsModel ToQcResultsModel(TestResult r)
        {
            return new TestResultsModel(r.TestResultId,r.DbId,r.Status,r.CpumaxTemp,r.GpumaxTemp,r.ErrorCount,r.WheaErrorCount,r.BatteryLife);        
        }
    }
}
