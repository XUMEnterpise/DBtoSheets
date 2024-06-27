using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadToSheets.DBContext;
using UploadToSheets.DTOS;
using UploadToSheets.Models;

namespace UploadToSheets.Services.QCResultsService
{
    public class DbToQCResultsModel : IQCResultsDbToModel
    {
        public async Task<IEnumerable<QCResultsModel>> GetQcModel()
        {
            using (ApplicationDbContext dBContext = new ApplicationDbContext())
            {
                IEnumerable<Qcresult> qcresults = await dBContext.Qcresults.ToListAsync();
                return qcresults.Select(r => ToQcResultsModel(r));
            }
        }
        private static QCResultsModel ToQcResultsModel(Qcresult r)
        {
            return new QCResultsModel(r.QcresultId, Int32.Parse(r.DbId),
                r.Verdict,r.SoundTestPassed,r.SoundTestPassed,r.IotestPassed,r.KeyboardTestPassed,r.CameraTestPassed,r.BatteryTestPassed,
                r.TouchpadTestPassed,r.ChargerTestPassed,r.CableManagementPassed,r.RgbAndLightsPassed,r.Notes,r.QctestDate,r.PixelTest,r.WifiTest);
        }
    }
}
