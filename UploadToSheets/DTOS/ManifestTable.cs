using System;
using System.Collections.Generic;

namespace UploadToSheets.DTOS;

public partial class ManifestTable
{
    public string? Prebuild { get; set; }

    public string? PrebuildSku { get; set; }

    public string? OrderNumber { get; set; }

    public string? OrderSku { get; set; }

    public DateTime? PackedDate { get; set; }
}
