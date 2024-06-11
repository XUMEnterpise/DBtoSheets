using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class ReplacedPart
{
    public int PartId { get; set; }

    public int? ReturnId { get; set; }

    public string? PartName { get; set; }

    public string? PartSku { get; set; }

    public int? Quantity { get; set; }

    public virtual ReturnsInfo? Return { get; set; }
}
