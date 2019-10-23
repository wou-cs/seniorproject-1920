using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example2.Controllers
{
    public class PersonController : Controller
    {
        private IList<SelectListItem> stateSelectList = new List<SelectListItem> {
            new SelectListItem {Value = "OR", Text="Oregon", Selected=true},
            new SelectListItem {Value = "WA", Text="Washington"},
            new SelectListItem {Value = "CA", Text="California"},
            new SelectListItem {Value = "ID", Text="Idaho"}
        };

        // GET: Person
        public ActionResult Index()
        {
            ViewBag.StateList = stateSelectList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string firstname, string lastname, int? age, string state)
        {
            if(ModelState.IsValid)
            {
                int a = age.GetValueOrDefault();
                IList<Person> output = new List<Person>();
                for(int i = 0; i < a; i++)
                {
                    output.Add(new Person { Age = i, FirstName = firstname, LastName = lastname, State = state });
                }

                ViewBag.PersonList = output;
                ViewBag.Success = true;
                ViewBag.StateList = stateSelectList;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }

        public struct Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string State { get; set; }
        }
    }
}