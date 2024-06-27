using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.Models;

namespace UploadToSheets.Services.WindowsKeyDataService
{
    public interface IDatabaseToWindowsKeyModel
    {
        public Task<IEnumerable<WindowsKeyModel>> GetWindowsKeyModels();
    }
}
