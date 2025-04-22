using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class APagePermission
{
    public int Id { get; set; }

    public int PageId { get; set; }

    public int RoleId { get; set; }

    public bool? IsList { get; set; }

    public bool? IsEdit { get; set; }

    public bool? IsDelete { get; set; }

    public bool? IsView { get; set; }
}
