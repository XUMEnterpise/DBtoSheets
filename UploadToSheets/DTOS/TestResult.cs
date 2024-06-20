using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

public partial class TestResult
{
    [Key]
    public int TestResultId { get; set; }

    [StringLength(25)]
    public string? DbId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("CPUMaxTemp", TypeName = "decimal(5, 2)")]
    public decimal? CpumaxTemp { get; set; }

    [Column("GPUMaxTemp", TypeName = "decimal(5, 2)")]
    public decimal? GpumaxTemp { get; set; }

    public int? ErrorCount { get; set; }

    public int? WheaErrorCount { get; set; }

    [StringLength(5)]
    public string? BatteryLife { get; set; }
}
