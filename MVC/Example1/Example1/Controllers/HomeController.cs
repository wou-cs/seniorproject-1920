using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1.Controllers
{
    public class HomeController : Controller
    {
        // GET /Home/Index
        // GET /Home
        // Get /
        public ActionResult Index()
        {
            return View();
        }

        // GET /Home/About
        public ActionResult About()
        {
            Debug.WriteLine(Request["value"]);
            Debug.WriteLine(Request["data"]);
            Debug.WriteLine(Request["data2"]);
            Double.TryParse(Request["data2"], out double data2);

            ViewBag.Message = "Your application description page.";
            ViewData["Message"] = "some string";
            int a = 20;
            int b = 2;
            double c = a + data2;
            ViewBag.C = c;

            return View();
        }

        // GET /Home/Contact
        public ActionResult Contact(double? data2)
        {
            ViewBag.Message = "Your contact page.";
            if(data2.HasValue)
            {
                ViewBag.Answer = data2;
            }
            else
            {
                ViewBag.Answer = 92.3;
            }
            return View();
        }
    }
}