using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1.Controllers
{
    public class TestAFormController : Controller
    {
        // GET: TestAForm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Form1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form1(int? numA)
        {
            ViewBag.ThankYou = "Thank you for your submission";
            ViewBag.NumA = (int)numA + 10;
            ViewBag.Success = false;
            if((int)numA < 100)
            {
                ViewBag.Success = true;
            }
            return View();
        }
    }
}