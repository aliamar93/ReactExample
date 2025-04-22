using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AUserPassword
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
