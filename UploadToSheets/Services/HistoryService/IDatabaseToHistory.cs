using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.Models;

namespace UploadToSheets.Services.HistoryService
{
    public interface IDatabaseToHistory
    {
        public Task<IEnumerable<HistoryModel>> GetHistoryModels();
    }
}
