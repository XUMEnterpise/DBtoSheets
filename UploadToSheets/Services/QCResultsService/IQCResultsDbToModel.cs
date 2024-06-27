using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.Models;

namespace UploadToSheets.Services.QCResultsService
{
    public interface IQCResultsDbToModel
    {
        public Task<IEnumerable<QCResultsModel>> GetQcModel();
    }
}
