using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services.ManifestTableService
{
    public class DatabaseManifestTable : IDatabaseManifestTable
    {
        public async Task<IEnumerable<ManifestModel>> GetManifestModels()
        {
            using (ApplicationDbContext dBContext = new ApplicationDbContext())
            {
                IEnumerable<ManifestTable> manifestTables = await dBContext.ManifestTables.ToListAsync();
                return manifestTables.Select(r => ToManifestModel(r));
            }
        }
        private static ManifestModel ToManifestModel(ManifestTable r)
        {
            return new ManifestModel(r.Prebuild,r.PrebuildSku,r.OrderNumber,r.OrderSku);
        }
    }
}
