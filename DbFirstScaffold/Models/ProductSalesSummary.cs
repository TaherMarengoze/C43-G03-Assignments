using System;
using System.Collections.Generic;

namespace DbFirstScaffold.Models;

public partial class ProductSalesSummary
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public int? TotalUnitsSold { get; set; }

    public double? TotalRevenue { get; set; }
}
