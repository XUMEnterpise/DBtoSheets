using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Table("QCResults")]
public partial class Qcresult
{
    [Key]
    [Column("QCResultId")]
    public int QcresultId { get; set; }

    [StringLength(25)]
    public string? DbId { get; set; }

    public bool? Verdict { get; set; }

    public bool? StressTestPassed { get; set; }

    public bool? SoundTestPassed { get; set; }

    [Column("IOTestPassed")]
    public bool? IotestPassed { get; set; }

    public bool? KeyboardTestPassed { get; set; }

    public bool? CameraTestPassed { get; set; }

    public bool? BatteryTestPassed { get; set; }

    public bool? TouchpadTestPassed { get; set; }

    public bool? ChargerTestPassed { get; set; }

    public bool? CableManagementPassed { get; set; }

    public bool? RgbAndLightsPassed { get; set; }

    [Column(TypeName = "text")]
    public string? Notes { get; set; }

    [Column("QCTestDate", TypeName = "datetime")]
    public DateTime? QctestDate { get; set; }

    public bool? PixelTest { get; set; }

    public bool? WifiTest { get; set; }
}
