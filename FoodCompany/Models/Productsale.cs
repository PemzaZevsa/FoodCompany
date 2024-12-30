using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Productsale
{
    public uint IdProductsale { get; set; }

    public uint IdProduct { get; set; }

    public uint IdSale { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Product IdProductNavigation { get; set; } = null!;

    public virtual Sale IdSaleNavigation { get; set; } = null!;
}
