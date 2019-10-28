using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_NoDB.DAL;
using User_NoDB.Models;

namespace User_NoDB.Controllers
{
    public class HomeController : Controller
    {
        public UserCollection uc = new UserCollection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeeUser()
        {
            User model = new User { FirstName = "Philip", LastName = "Collins", DOB = new DateTime(1960, 11, 1) };

            return View(model);
        }

        public ActionResult AllUsers()
        {
            return View(uc.Users.ToList());
        }
        // GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                // Model binder found FirstName, LastName and DOB in the form values
                uc.Users.Add(user);
                Debug.WriteLine(user);
                return RedirectToAction("AllUsers");
            }
            else
            {
                // Bad input, send them back to the form
                return View();
            }
            
        }
    }
}