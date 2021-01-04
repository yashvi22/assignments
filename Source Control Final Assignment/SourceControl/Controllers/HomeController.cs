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
        public ActionResult Register(employees_details register)
        {
            if(ModelState.IsValid)
            {
                using (employeesEntities context = new employeesEntities())
                {
                    context.employees_details.Add(register);
                    context.SaveChanges();
                    int id = register.Id;

                }
                

            }
            
            return RedirectToAction("Login");
        }

        //login page
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                using (employeesEntities context= new employeesEntities())
                {
                    var query= context.employees_details.Where(a=>a.Email.Equals(login.Email) && a.Password.Equals(login.Password)).FirstOrDefault();  
                    if (query !=null)
                    {
                        Session["Id"] = query.Id;
                        Session["Email"] = query.Email;
                        return RedirectToAction("Dashboard");

                    }
                }
            }
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}