using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.API.Security;
using Students.API.Models;

namespace Students.API.Controllers
{
    public class DemoController : Controller
    {
        [AllowAnonymous]
        public ActionResult Work0()
        {
            return View();
        }

        [CustomAuthorize(Roles = "superadmin")]
        public ActionResult Work1()
        {
            return View("Work1");
        }

        [CustomAuthorize(Roles = "superadmin,admin")]
        public ActionResult Work2()
        {
            return View("Work2");
        }

        [CustomAuthorize(Roles = "superadmin,admin,employee")]
        public ActionResult Work3()
        {
            return View("Work3");
        }
    }
}