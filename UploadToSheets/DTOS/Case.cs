using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Keyless]
[Table("CASES")]
public partial class Case
{
    [Column("CASE")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Case1 { get; set; }
}
