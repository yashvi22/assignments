using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class UserController : Controller
    {
        PMSEntities dbcontext = new PMSEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Users model)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:60970/api/UserApi");
            var consume = hc.PostAsJsonAsync<Users>("UserApi", model);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            var user = dbcontext.Users.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
            if (user != null)
            {

                Session["Id"] = model.Id.ToString(); 
                Session["Email"] = model.Email.ToString(); 
                TempData["LoginSuccessMsg"] = "<script>alert('Logged in successfully!')</script>"; 
                return RedirectToAction("Dashboard"); 
            }
            return View();
        }

        
    }

}