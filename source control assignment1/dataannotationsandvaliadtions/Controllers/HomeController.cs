using dataannotationsandvalidations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataannotationsandvalidations.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(RegistrationModel rm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Firstname = rm.FirstName;
                ViewBag.Lastname = rm.LastName;
                ViewBag.Age = rm.Age;
                ViewBag.Email = rm.Email;
                ViewBag.Password= rm.Password;
                return View("Index");
            }

            else
            {
                ViewBag.Firstname = "No Data";
                ViewBag.Lastname = "No Data";
                ViewBag.Age = "No Data";
                ViewBag.Email = "No Data";
                ViewBag.Password = "No Data";
                return View("Index");
            }

        }
    }
}