using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services.HistoryService
{
    public class DatabaseToHistoryService : IDatabaseToHistory
    {
        public Task<IEnumerable<HistoryModel>> GetHistoryModels()
        {
            using(ApplicationDbContext dBContext = new ApplicationDbContext())
            {
                IEnumerable<History> history = dBContext.Histories.ToList();
                return Task.FromResult(history.Select(r => ToHistoryModel(r)));
            }
        }

        private static HistoryModel ToHistoryModel(History r)
        {
            return new HistoryModel(r.Id,r.Orderid,r.Sku,Int32.Parse(r.Qty),r.Channel,r.Date,r.IsTested,r.TestedBy,r.TestStatus,r.PackedBy,r.PackedDate,r.AssignedNumber);
        }
    }
}
