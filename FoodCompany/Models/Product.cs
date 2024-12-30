using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Product
{
    public uint IdProduct { get; set; }

    public string Name { get; set; } = null!;

    public decimal Weight { get; set; }

    public decimal Cost { get; set; }

    public uint? IdSale { get; set; }

    public virtual Sale? IdSaleNavigation { get; set; }

    public virtual ICollection<Productorder> Productorders { get; set; } = new List<Productorder>();

    public virtual ICollection<Productsale> Productsales { get; set; } = new List<Productsale>();

    public virtual ICollection<Category> IdCategories { get; set; } = new List<Category>();

    public virtual ICollection<Ingredient> IdIngredients { get; set; } = new List<Ingredient>();
}
