using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

public partial class ReplacedPart
{
    [Key]
    public int PartId { get; set; }

    public int? ReturnId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? PartName { get; set; }

    [Column("PartSKU")]
    [StringLength(255)]
    [Unicode(false)]
    public string? PartSku { get; set; }

    public int? Quantity { get; set; }

    [ForeignKey("ReturnId")]
    [InverseProperty("ReplacedParts")]
    public virtual ReturnsInfo? Return { get; set; }
}
