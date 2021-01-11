using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace ProductManagementSystem.Controllers
{
    public class UsersController : Controller
    {
        HttpClient hc = new HttpClient();
        // GET: Users
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserModel model)
        {

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel model)
        {
            
            return RedirectToAction("Dashboard","Products",model.Id);
        }
    }
}