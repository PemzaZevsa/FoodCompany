using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodCompany.Models;

public partial class Person
{
    public uint IdPerson { get; set; }

    [DisplayName("Ім'я")]
    [MinLength(4)]
    public string Name { get; set; } = null!;

    [DisplayName("Прізвище")]
    [MinLength(4)]
    public string Surname { get; set; } = null!;

    [DisplayName("Номер телефону")]
    [MinLength(12)]
    public string PhoneNumber { get; set; } = null!;

    [DisplayName("Електронна адреса")]
    public string Email { get; set; } = null!;

    [DisplayName("Адреса проживання")]
    public string Address { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Employee? Employee { get; set; }
}
