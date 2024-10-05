using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_MVC_auth_cookiee.Models;
using static System.Console;
using static WebApp_MVC_auth_cookiee.Models.Students;

namespace WebApp_MVC_auth_cookiee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="master")]
        public IActionResult Master()
        {
            return View();
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");
            return View();
        }

        public async Task<IActionResult>  Logout()
        {
            if (User.Identity.IsAuthenticated)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public async Task<IActionResult> Check(string? id, string pass)
        {
            if (User.Identity.IsAuthenticated) return Redirect("/");

            WriteLine($"{id} -- {pass}");
            Student? student = students.FirstOrDefault(x => x.Id == id && x.Pass == pass);

            if (student is null)
            {
                { } WriteLine("login failed..");
                return View("Error", model: new ErrorViewModel { RequestId = "Failed login" });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, student.Id),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, student.Role.Name)
            };

            var claimId = new ClaimsIdentity(claims, "Cookies");
            var claimPrincipial = new ClaimsPrincipal(claimId);
            await HttpContext.SignInAsync(claimPrincipial);

            return Redirect("/");
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
    }
}
