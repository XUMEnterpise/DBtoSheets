using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Keyless]
[Table("ManifestTable")]
public partial class ManifestTable
{
    [StringLength(50)]
    public string? Prebuild { get; set; }

    [Column("PrebuildSKU")]
    [StringLength(250)]
    public string? PrebuildSku { get; set; }

    [StringLength(50)]
    public string? OrderNumber { get; set; }

    [Column("OrderSKU")]
    [StringLength(250)]
    public string? OrderSku { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PackedDate { get; set; }
}
