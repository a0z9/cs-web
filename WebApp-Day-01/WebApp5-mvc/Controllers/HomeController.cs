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
    }
}
