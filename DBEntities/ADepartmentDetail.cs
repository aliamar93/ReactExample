using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class ADepartmentDetail
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public decimal PersonalNr { get; set; }

    public string? Status { get; set; }

    public int? RoleId { get; set; }

    public string? WorkStation { get; set; }
}
