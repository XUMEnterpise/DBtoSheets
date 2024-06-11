using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class Qcresult
{
    public int QcresultId { get; set; }

    public string? DbId { get; set; }

    public bool? Verdict { get; set; }

    public bool? StressTestPassed { get; set; }

    public bool? SoundTestPassed { get; set; }

    public bool? IotestPassed { get; set; }

    public bool? KeyboardTestPassed { get; set; }

    public bool? CameraTestPassed { get; set; }

    public bool? BatteryTestPassed { get; set; }

    public bool? TouchpadTestPassed { get; set; }

    public bool? ChargerTestPassed { get; set; }

    public bool? CableManagementPassed { get; set; }

    public bool? RgbAndLightsPassed { get; set; }

    public string? Notes { get; set; }

    public DateTime? QctestDate { get; set; }

    public bool? PixelTest { get; set; }

    public bool? WifiTest { get; set; }
}
