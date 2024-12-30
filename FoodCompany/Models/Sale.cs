using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Sale
{
    public uint IdSale { get; set; }

    public string Name { get; set; } = null!;

    public decimal Discount { get; set; }

    public virtual ICollection<Productorder> Productorders { get; set; } = new List<Productorder>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Productsale> Productsales { get; set; } = new List<Productsale>();
}
