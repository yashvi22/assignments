﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControl.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
       public ActionResult Registration()
        {
            return View();
        }

        
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}