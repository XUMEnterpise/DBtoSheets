using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.Models;

namespace UploadToSheets.Services.ManifestTableService
{
    public interface IDatabaseManifestTable
    {
        public Task<IEnumerable<ManifestModel>> GetManifestModels();
    }
}
