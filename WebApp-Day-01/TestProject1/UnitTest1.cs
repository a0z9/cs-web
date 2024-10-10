using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WebApp_MVC_test.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace TestProject1
{
    public class Tests
    {
        public HomeController ctr;

        private readonly ILogger<HomeController> logger = new NullLogger<HomeController>();

        [TearDown]
        public void Clear() { 
         ctr.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            ctr = new HomeController(logger);
        }

        [Test]
        public void TestHomeController()
        {
           //  HomeController ctr = new HomeController(logger);
            //var ctx = MockRepository.


            ViewResult res = ctr.Index() as ViewResult;


            Assert.IsNotNull(res);
        }

        [Test]
        public void TestIndexPage() {
            ViewResult res = ctr.Index() as ViewResult;
            var actual = res.ViewData["test"] as string;

            Assert.AreEqual(actual, "Ok2");
        }


    }
}