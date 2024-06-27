
using UploadToSheets.Models;

namespace UploadToSheets.Services.TestResultsService
{
    public interface ITestResultsToModel
    {
        public Task<IEnumerable<TestResultsModel>> GetTestResultsModel();
    }
}
