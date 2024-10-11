using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using WebApp_MVC_test.Controllers;
using Microsoft.AspNetCore.Mvc;
using wapp5 = WebApp5_mvc.Controllers;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web;


namespace TestProject1
{
    public class Tests
    {
        public HomeController ctr;
        public wapp5.HomeController ctr2;

        private Mock<ILogger<wapp5.HomeController>> mockLogger = new Mock<ILogger<wapp5.HomeController>>(MockBehavior.Strict);
        private readonly ILogger<HomeController> logger = new NullLogger<HomeController>();


        [TearDown]
        public void Clear() { 
         ctr.Dispose();
         ctr2.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            ctr2 = new wapp5.HomeController(mockLogger.Object);
            ctr = new HomeController(logger);
        }


        [Test]
        public void TestHomeController5()
        {
           
            //Mock<ILogger<wapp5.HomeController>> mockLogger = new Mock<ILogger<wapp5.HomeController>>(MockBehavior.Strict);
          
            //wapp5.HomeController ctr2 = new wapp5.HomeController(mockLogger.Object);
            //wapp5.HomeController ctr2 = new wapp5.HomeController(new NullLogger<wapp5.HomeController>());

            ctr2.ControllerContext.HttpContext  = new DefaultHttpContext();
            ctr2.ControllerContext.HttpContext.Request.Headers["AAA"] = "BBB";

            Mock<ISession> sessionMock =
              new Mock<ISession>(MockBehavior.Default);

            ctr2.ControllerContext.HttpContext.Session = sessionMock.Object;

            var sess = sessionMock.Object;
            sess.SetString("sess_data", "good test"); // fake save!

           
            ViewResult res = ctr2.Index() as ViewResult;
            
                 Assert.IsNotNull(res);
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

            Assert.AreEqual(actual, "Ok");
        }


    }

   

}