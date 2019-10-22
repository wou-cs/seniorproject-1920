using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1a.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Number = 74;
            ViewData["Number2"] = 74;
            ViewBag.Success = true;
            ViewBag.Red = Request.QueryString["Red"];
            ViewBag.Blue = Request.QueryString["Blue"];

            return View();
        }

        public ActionResult Contact(string red, string blue)
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Colors = "Red = " + red + " Blue = " + blue;

            return View();
        }
    }
}