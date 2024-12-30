using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Customer
{
    public uint IdCustomer { get; set; }

    public decimal PurchaseSum { get; set; }

    public decimal CustomerDiscount { get; set; }

    public virtual Person IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
