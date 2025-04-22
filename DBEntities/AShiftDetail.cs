using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AShiftDetail
{
    public int Id { get; set; }

    public int ShiftId { get; set; }

    public DateTime? ToDateTime { get; set; }

    public DateTime? FromDateTime { get; set; }

    public decimal? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
