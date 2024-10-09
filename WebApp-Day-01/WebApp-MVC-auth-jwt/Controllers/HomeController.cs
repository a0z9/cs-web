using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp_MVC_auth_jwt.Models;
using static System.Console;
using static WebApp_MVC_auth_jwt.Models.Students;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace WebApp_MVC_auth_jwt.Controllers
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

        //public IActionResult Test() => View();


        [Route("t")]
        public IActionResult Test() => View();

        public IActionResult Status(int id) {
            ViewData["status_code"] = id;
            return View(); }
    

        [Authorize(Roles ="master, phd")]
        public IActionResult Master()
        {
            return View();
        }

        [Authorize(Roles = "phd")]
        public IActionResult Phd()
        {
            return View();
        }

        [Authorize(Roles = "phd, master, bachelor")]
        public IActionResult Bachelor()
        {
            return View();
        }

        public IActionResult Denied() {
            return View();
        }

        public IActionResult Login()
        {
            //if (User.Identity.IsAuthenticated) return Redirect("/");
            return View();
        }

        public async Task<IActionResult>  Logout()
        {
            if (User.Identity.IsAuthenticated) { }
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Check(string id, string pass, string url)
        {
            //if (User.Identity.IsAuthenticated) return Redirect("/");

            WriteLine($"{Request.Query["id"]} -- {Request.Query["pass"]}");

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

            var jwt = new JwtSecurityToken(
                issuer:AOPtions.ISSUER,
                audience:AOPtions.AUDIENCE,
                claims: claims,
                signingCredentials: new SigningCredentials(AOPtions.GetKey(),SecurityAlgorithms.HmacSha256),
                expires: DateTime.Now.Add(TimeSpan.FromSeconds(120))
                );

            var jwt2 = new JwtSecurityTokenHandler().WriteToken(jwt); //base64 encoded token


            WriteLine(jwt2);

            //var claimId = new ClaimsIdentity(claims, "Cookies");
            //var claimPrincipial = new ClaimsPrincipal(claimId);
            //await HttpContext.SignInAsync(claimPrincipial);

            //if (String.IsNullOrEmpty(url) || url=="null") url = "/";
            //return Redirect(url);
            ViewData["token"]=jwt2;
            return View();
        }

        public IActionResult Proxy(string pg, string tkn)
        {
            Request.Headers.Append("Authorization", $"Bearer {tkn}");
            return RedirectToAction(pg);
        }

        public IActionResult Privacy()
        {
            WriteLine($"prive test: {ViewData["tkn"]}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
