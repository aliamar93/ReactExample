using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AUrlaubDetail
{
    public int Id { get; set; }

    public int UrlaubId { get; set; }

    public DateTime? ToDate { get; set; }

    public DateTime? FromDate { get; set; }

    public decimal? ApprovedBy { get; set; }

    public DateTime? ApprovedDate { get; set; }
}
