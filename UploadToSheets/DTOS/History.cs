using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Table("History")]
public partial class History
{
    [Key]
    public int Id { get; set; }

    [StringLength(10)]
    public string Orderid { get; set; } = null!;

    [Column("SKU")]
    [StringLength(50)]
    public string Sku { get; set; } = null!;

    [Column("QTY")]
    [StringLength(10)]
    public string Qty { get; set; } = null!;

    [StringLength(20)]
    public string? Channel { get; set; }

    public DateOnly Date { get; set; }

    public bool IsTested { get; set; }

    [StringLength(25)]
    public string TestedBy { get; set; } = null!;

    [StringLength(25)]
    public string TestStatus { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
    public string? PackedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PackedDate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? AssignedNumber { get; set; }
}
