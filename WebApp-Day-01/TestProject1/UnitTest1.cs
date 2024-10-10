using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WebApp5_mvc.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace TestProject1
{
    public class Tests
    {

        private readonly ILogger<HomeController> logger = new NullLogger<HomeController>();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHomeController()
        {
            HomeController ctr = new HomeController(logger);
            ViewResult res = ctr.Index() as ViewResult;


            Assert.IsNotNull(res);
        }

        [Test]
        public void TestIndexPage() { 
        
        
        }


    }
}