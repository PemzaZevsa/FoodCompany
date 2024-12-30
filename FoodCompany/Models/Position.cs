using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Position
{
    public uint IdPosition { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
