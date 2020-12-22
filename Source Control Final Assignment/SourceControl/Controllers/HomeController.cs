using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using SourceControl.Models;

namespace SourceControl.Controllers
{
    public class HomeController : Controller
    {
        //home page
        public ActionResult Index()
        {
            return View();
        }

        //registration page
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterDetails(RegistrationModel register)
        {
                using (var databaseContext= new employeesEntities())
                {
                    RegisterationModelDB model = new RegisterationModelDB();
                    {
                        model.FirstName = register.FirstName;
                        model.LastName = register.LastName;
                        model.DateOfBirth = register.DateOfBirth;
                        model.Age = register.Age;
                        model.Email = register.Email;
                        model.Password = register.Password;
                        model.Qualification = register.Qualification;
                        model.Phone = register.Phone;

                    }

                databaseContext.RegisterationModelDB.Add(model);
                databaseContext.SaveChanges();
                
            }

            return RedirectToAction("Dashboard);
        }

        //login page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            return View();
        }


    }
}