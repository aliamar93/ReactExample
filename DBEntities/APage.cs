using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class APage
{
    public int Id { get; set; }

    public string? PageName { get; set; }

    public string? Url { get; set; }
}
