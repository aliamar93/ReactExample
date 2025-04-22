using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AShift
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public DateTime? DateTime { get; set; }

    public decimal? AuthorizedBy { get; set; }

    public DateTime? AuthorizedDate { get; set; }

    public decimal? AssignedBy { get; set; }

    public decimal? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? Status { get; set; }
}
