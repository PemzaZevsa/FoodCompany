using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Productorder
{
    public uint IdOrder { get; set; }

    public uint IdProduct { get; set; }

    public uint Amount { get; set; }

    public decimal Cost { get; set; }

    public decimal DiscountCost { get; set; }

    public uint? IdSale { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Sale? IdSaleNavigation { get; set; }
}
