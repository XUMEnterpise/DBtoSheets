using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UploadToSheets.DTOS;

[Table("CustomerInfo")]
public partial class CustomerInfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OrderID")]
    [StringLength(25)]
    public string? OrderId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? CustomerName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ChannelReference { get; set; }
}
