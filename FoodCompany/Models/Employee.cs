using FoodCompany.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

public partial class Employee
{
    [DisplayName("Id Людини")]
    public uint IdEmployee { get; set; }

    [DisplayName("Логін")]
    public string Login { get; set; } = null!;

    [DisplayName("Пароль")]
    public string Password { get; set; } = null!;

    [DisplayName("Заробітня плата")]
    public decimal Salary { get; set; }

    [DisplayName("Посада")]
    public uint IdPosition { get; set; }

    public DateTime HireDate { get; set; }

    public virtual Person IdEmployeeNavigation { get; set; } = null!;

    [ForeignKey("IdPosition")]
    public virtual Position IdPositionNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
