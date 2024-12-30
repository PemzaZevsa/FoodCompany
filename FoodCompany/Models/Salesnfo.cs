using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Salesnfo
{
    public string CustomerNameSurname { get; set; } = null!;

    public string EmployeeNameSurname { get; set; } = null!;

    public decimal FinalCost { get; set; }

    public DateTime PurchaseDate { get; set; }

    public uint Amount { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Weight { get; set; }

    public decimal Cost { get; set; }

    public string SaleName { get; set; } = null!;

    public decimal Discount { get; set; }
}
