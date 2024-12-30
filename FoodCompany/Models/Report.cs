using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Report
{
    public uint IdReport { get; set; }

    public uint IdTimeInterval { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? PopularCategories { get; set; }

    public string PopularProducts { get; set; } = null!;

    public decimal Profit { get; set; }

    public decimal? PopularProductsProfit { get; set; }

    public decimal? PopularProductsProfitPercentage { get; set; }

    public virtual Timeinterval IdTimeIntervalNavigation { get; set; } = null!;
}
