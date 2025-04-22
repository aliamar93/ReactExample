using System;
using System.Collections.Generic;

namespace AutostoreProject.DBEntities;

public partial class AUrlaub
{
    public int Id { get; set; }

    public decimal PersonalNr { get; set; }

    public int? NoOfDays { get; set; }

    public DateTime? CreatedDateTime { get; set; }
}
