using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class ReturnsInfo
{
    public int ReturnId { get; set; }

    public string? OrderId { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? Status { get; set; }

    public string? ReasonForReturn { get; set; }

    public string? AdditionalReturnInfo { get; set; }

    public string? Diagnosis { get; set; }

    public string? AdditionalRepairInfo { get; set; }

    public virtual ICollection<ReplacedPart> ReplacedParts { get; set; } = new List<ReplacedPart>();
}
