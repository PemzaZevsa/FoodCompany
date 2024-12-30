using FoodCompany.DataTransferObjects;
using FoodCompany.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodCompany.Controllers
{
    public class HomeController(FoodCompanyContext context) : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            var UserDto = new UserDto { ReturnUrl = HttpContext.Request.Query["ReturnUrl"].ToString() };
            return View(UserDto);
        }

        public IActionResult LoginPost(UserDto userDto)
        {
            if (!ModelState.IsValid) return View("Login", userDto);

            var dbUser = context.Employees
                .FirstOrDefault(user => user.Login == userDto.Login && user.Password == userDto.Password);

            if (dbUser == null)
            {
                ModelState.AddModelError("Password", "Invalid login or password");
                return View("Login", userDto);
            }

            string userRole = dbUser.IdPosition.ToString(); 

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(
                    new List<Claim>
                    {
                new Claim(ClaimTypes.Name, dbUser.Login),
                new Claim(ClaimTypes.Role, userRole) 
                    },
                    CookieAuthenticationDefaults.AuthenticationScheme)));

            if (!string.IsNullOrWhiteSpace(userDto.ReturnUrl) && Url.IsLocalUrl(userDto.ReturnUrl))
                return Redirect(userDto.ReturnUrl);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logoff()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult ListPerson()
        {
            var personsList = context.People
                .OrderBy(person => person.Surname).ToList();

            return View(personsList);
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person obj)
        {
            if (ModelState.IsValid)
            {
                context.People.Add(obj);
                context.SaveChanges();
                TempData["success"] = "Користувача успішно додано!";

                return RedirectToAction("ListPerson");
            }

            return View();
        }

        public IActionResult EditPerson(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Person? person = context.People.Where(p => p.IdPerson == id).FirstOrDefault();

            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                context.People.Update(person);
                context.SaveChanges();
                TempData["success"] = "Користувача успішно змінено!";

                return RedirectToAction("ListPerson");
            }

            return View();
        }

        public IActionResult DeletePerson(int id)
        {
            Person? person = context.People.Where(p => p.IdPerson == id).FirstOrDefault();

            if (person is null)
            {
                return NotFound();
            }

            context.People.Remove(person);
            context.SaveChanges();
            TempData["success"] = "Користувача успішно видалено!";

            return RedirectToAction("ListPerson");
        }
    }
}
