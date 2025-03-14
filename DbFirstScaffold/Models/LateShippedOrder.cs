using System;
using System.Collections.Generic;

namespace DbFirstScaffold.Models;

public partial class LateShippedOrder
{
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? DaysLate { get; set; }
}
