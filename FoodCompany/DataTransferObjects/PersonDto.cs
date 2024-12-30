using FoodCompany.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodCompany.DataTransferObjects
{
    public record PersonDto
    (
        Person user,
        int IdPerson,
        IEnumerable<SelectListItem> PersonList,
        IEnumerable<SelectListItem> RoleList
    );    
}