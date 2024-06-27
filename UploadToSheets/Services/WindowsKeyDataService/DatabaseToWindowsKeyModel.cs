using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services.WindowsKeyDataService
{
    public class DatabaseToWindowsKeyModel : IDatabaseToWindowsKeyModel
    {
        public async Task<IEnumerable<WindowsKeyModel>> GetWindowsKeyModels()
        {
            using (ApplicationDbContext dBContext = new ApplicationDbContext())
            {
                IEnumerable<WindowsKeyDatum> keyData = await dBContext.WindowsKeyData.ToListAsync();
                return keyData.Select(r => ToWindowsKeyModel(r));
            }
        }

        private WindowsKeyModel ToWindowsKeyModel(WindowsKeyDatum r)
        {
            return new WindowsKeyModel(r.Date, r.Agent, r.ServiceTag, r.WindowsKey, r.IsActivated, r.Sku, r.Cpu, r.WindowsVersion);
        }
    }
}
