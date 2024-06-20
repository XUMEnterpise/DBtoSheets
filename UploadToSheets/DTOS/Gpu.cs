using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Keyless]
[Table("GPUS")]
public partial class Gpu
{
    [Column("GPU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Gpu1 { get; set; }
}
