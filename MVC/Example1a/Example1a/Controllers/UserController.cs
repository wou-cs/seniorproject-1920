using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example1a.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: ~/User/CreateMessage
        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMessage(string name, string email, string message)
        {
            ViewBag.name = name;
            ViewBag.email = email;
            ViewBag.message = message;

            return View();
        }
    }
}