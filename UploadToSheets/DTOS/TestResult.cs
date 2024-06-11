using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class TestResult
{
    public int TestResultId { get; set; }

    public string? DbId { get; set; }

    public string? Status { get; set; }

    public decimal? CpumaxTemp { get; set; }

    public decimal? GpumaxTemp { get; set; }

    public int? ErrorCount { get; set; }

    public int? WheaErrorCount { get; set; }

    public string? BatteryLife { get; set; }
}
