using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Deliverystatus
{
    public uint IdDeliveryStatus { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
