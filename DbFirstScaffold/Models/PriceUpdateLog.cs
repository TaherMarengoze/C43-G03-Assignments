using System;
using System.Collections.Generic;

namespace DbFirstScaffold.Models;

public partial class PriceUpdateLog
{
    public int? ProductId { get; set; }

    public decimal? OldPrice { get; set; }

    public decimal? NewPrice { get; set; }

    public DateTime UpdateDate { get; set; }
}
