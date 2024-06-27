using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

public partial class WindowsKeyDatum
{
    public DateOnly? Date { get; set; }

    [StringLength(100)]
    public string? Agent { get; set; }

    [Key]
    [StringLength(100)]
    public string ServiceTag { get; set; } = null!;

    [StringLength(100)]
    public string? WindowsKey { get; set; }

    [Column("isActivated")]
    public bool? IsActivated { get; set; }

    [Column("SKU")]
    [StringLength(100)]
    public string? Sku { get; set; }

    [Column("CPU")]
    [StringLength(50)]
    public string? Cpu { get; set; }

    [StringLength(50)]
    public string? WindowsVersion { get; set; }
}
