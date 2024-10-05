using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp5_mvc.Models;
using static System.Console;
using System.Text.Json;

namespace WebApp5_mvc.Controllers
{
    public record class Student(string Name="Basil", int id=1265765);
        
        public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            WriteLine($"+++ ctrl: {GetHashCode():x}");
        }

        public IActionResult Index()
        {
            var sess = HttpContext.Session;
            foreach (var k in sess.Keys) WriteLine($"{k} -> {sess.GetString(k)}");
            if (sess.Keys.Contains("sess_data"))
            {
                WriteLine($"Sess (id:{sess.Id}) data exists = {sess.GetString("sess_data")}");
                
            }
            else {
                int d = new Random().Next(10, 1_000_000);
                sess.SetString("sess_data", $"{d}");
                
                WriteLine($"Sess init {sess.Id}, data set to {d}");
            }

            if (sess.Keys.Contains("student"))
            {
                WriteLine($"Sess (id:{sess.Id}) data exists = {sess.GetString("student")}");

            }
            else
            {
                Student st = new Student();

                sess.SetString("student", JsonSerializer.Serialize<Student>(st));

                WriteLine($"Sess init {sess.Id}, Student -> {sess.GetString("student")}");
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Status(int id)
        {
            if (id == 404) return View("404");
            return View(model: new StatusCodeModel { StatusCode = id});
          //     WriteLine($"Error status code: {id}");
        }

        public void s(int? code) {

            //code = code ?? 500;
            Response.StatusCode = code ?? 500;
           // return View();
        }

        public void Err() {

            int a = 1;
            int b = 12 / (a - 1);
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error2()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
