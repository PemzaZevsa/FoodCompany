using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Category
{
    public uint IdCategory { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> IdProducts { get; set; } = new List<Product>();
}
