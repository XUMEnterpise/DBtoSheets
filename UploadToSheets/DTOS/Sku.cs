using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class Sku
{
    public string? Sku1 { get; set; }

    public string? Case { get; set; }

    public string? Mobo { get; set; }

    public string? Cpu { get; set; }

    public string? Ram { get; set; }

    public string? Gpu { get; set; }

    public string? Hdd { get; set; }

    public string? Ssd { get; set; }

    public int Id { get; set; }

    public string Windows { get; set; } = null!;
}
