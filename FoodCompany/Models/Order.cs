using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Order
{
    public uint IdOrder { get; set; }

    public uint IdCustomer { get; set; }

    public uint IdDeliveryStatus { get; set; }

    public uint IdEmployee { get; set; }

    public decimal OrderCost { get; set; }

    public decimal FinalCost { get; set; }

    public DateTime PurchaseDate { get; set; }

    public DateTime DeliveryStatusChange { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual Deliverystatus IdDeliveryStatusNavigation { get; set; } = null!;

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<Productorder> Productorders { get; set; } = new List<Productorder>();
}
