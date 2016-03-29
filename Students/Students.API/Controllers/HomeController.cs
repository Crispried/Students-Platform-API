﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Documentation()
        {
            ViewBag.Title = "API documentation";
            return View();
        }

        public ActionResult Housing()
        {
            return View();
        }

        public ActionResult Travel()
        {
            return View();
        }

        public ActionResult Market()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }
    }
}
