using FoodCompany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FoodCompany.Controllers
{
    public class AdminController(FoodCompanyContext context) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListEmployee()
        {
            var personsList = context.Employees
                .Include(employee => employee.IdPositionNavigation) 
                .OrderBy(employee => employee.IdPosition)  
                .ToList();

            return View(personsList);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee obj)
        {
            var personExists = context.People.Any(p => p.IdPerson == obj.IdEmployee);
            if (!personExists)
            {
                ModelState.AddModelError("IdEmployee", "Такої людини не існує");
                return View(obj); 
            }

            if (ModelState.IsValid)
            {
                context.Employees.Add(obj);
                context.SaveChanges();
                TempData["success"] = "Користувача успішно додано!";
                return RedirectToAction("ListEmployee");
            }

            return View(obj);  
        }

        public IActionResult EditEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Employee? person = context.Employees.Where(p => p.IdEmployee== id).FirstOrDefault();

            return View(person);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee obj)
        {
            var personExists = context.People.Any(p => p.IdPerson == obj.IdEmployee);

            if (!personExists)
            {
                ModelState.AddModelError("IdEmployee", "Людини з таким Id не існує");
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                context.Employees.Update(obj);
                context.SaveChanges();
                TempData["success"] = "Користувача успішно змінено!";

                return RedirectToAction("ListPerson");
            }

            return View();
        }

        public IActionResult DeleteEmployee(int id)
        {
            Employee? employee = context.Employees.Where(p => p.IdEmployee == id).FirstOrDefault();

            if (employee is null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            context.SaveChanges();
            TempData["success"] = "Користувача успішно видалено!";

            return RedirectToAction("ListPerson");
        }
    }
}
