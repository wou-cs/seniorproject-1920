using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_noDB_2.DAL;
using User_noDB_2.Models;

namespace User_noDB_2.Controllers
{
    public class UserController : Controller
    {
        public UserCollection uc = new UserCollection();

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                uc.Users.Add(user);
                Debug.WriteLine(user);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        // GET: /User/Display
        public ActionResult Display()
        {
            return View(uc.Users);
        }
    }
}