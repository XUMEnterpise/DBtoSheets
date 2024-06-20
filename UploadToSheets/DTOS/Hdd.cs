using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Keyless]
[Table("HDDS")]
public partial class Hdd
{
    [Column("HDD")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Hdd1 { get; set; }
}
