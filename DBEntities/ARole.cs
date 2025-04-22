using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class ARole
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public decimal? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public decimal? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
