using System;
using System.Collections.Generic;

namespace FoodCompany.Models;

public partial class Timeinterval
{
    public uint IdTimeInterval { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
