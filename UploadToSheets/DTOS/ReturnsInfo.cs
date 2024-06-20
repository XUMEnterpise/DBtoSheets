using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Table("ReturnsInfo")]
public partial class ReturnsInfo
{
    [Key]
    public int ReturnId { get; set; }

    [Column("OrderID")]
    [StringLength(25)]
    public string? OrderId { get; set; }

    public DateOnly? ReturnDate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ReasonForReturn { get; set; }

    [Column(TypeName = "text")]
    public string? AdditionalReturnInfo { get; set; }

    [Column(TypeName = "text")]
    public string? Diagnosis { get; set; }

    [Column(TypeName = "text")]
    public string? AdditionalRepairInfo { get; set; }

    [InverseProperty("Return")]
    public virtual ICollection<ReplacedPart> ReplacedParts { get; set; } = new List<ReplacedPart>();
}
