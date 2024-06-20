using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Keyless]
[Table("MOTHERBOARDS")]
public partial class Motherboard
{
    [Column("MOTHERBOARD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Motherboard1 { get; set; }
}
