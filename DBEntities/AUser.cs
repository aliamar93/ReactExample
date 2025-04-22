using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AUser
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? PersonalNr { get; set; }

    public string? Image { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Status { get; set; }

    public string? Islinked { get; set; }

    public int? Attempt { get; set; }
}
