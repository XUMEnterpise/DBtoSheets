using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadToSheets.Models
{
    public class QCResultsModel
    {
        public QCResultsModel(int qCResultID, int dbId, bool? verdict, bool? stressTestPassed, bool? soundTestPassed, bool? iOTestPassed, bool? keyboardTestPassed, bool? cameraTestPassed, bool? bateryTestPassed, bool? touchpadPassed, bool? chargerPassed, bool? cableManagementPassed, bool? rgbAndLightingPassed, string? notes, DateTime? qCDate, bool? pixelTest, bool? wifiTest)
        {
            QCResultID = qCResultID;
            DbId = dbId;
            Verdict = verdict;
            StressTestPassed = stressTestPassed;
            SoundTestPassed = soundTestPassed;
            IOTestPassed = iOTestPassed;
            KeyboardTestPassed = keyboardTestPassed;
            CameraTestPassed = cameraTestPassed;
            BateryTestPassed = bateryTestPassed;
            TouchpadPassed = touchpadPassed;
            ChargerPassed = chargerPassed;
            CableManagementPassed = cableManagementPassed;
            RgbAndLightingPassed = rgbAndLightingPassed;
            Notes = notes;
            QCDate = qCDate;
            PixelTest = pixelTest;
            WifiTest = wifiTest;
        }

        public int QCResultID { get; private set; }
        public int DbId { get; private set; }
        public bool? Verdict { get; private set; }
        public bool? StressTestPassed { get; private set; }
        public bool? SoundTestPassed { get; private set; }
        public bool? IOTestPassed { get; private set; }
        public bool?  KeyboardTestPassed { get; private set; }
        public bool? CameraTestPassed { get; private set; }
        public bool? BateryTestPassed { get; private set; }
        public bool? TouchpadPassed { get; private set; }
        public bool? ChargerPassed { get; private set; }
        public bool? CableManagementPassed { get; private set; }
        public bool? RgbAndLightingPassed { get; private set; }
        public string? Notes { get; private set; }
        public DateTime? QCDate { get; private set; }
        public bool? PixelTest { get; private set; }
        public bool? WifiTest { get; private set; } 

    }
}
