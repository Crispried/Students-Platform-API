using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.API.Models;
using Students.API.Security;
using Students.API.ViewModels;

namespace Students.API.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            UserModel am = new UserModel();
            if (am.Login(avm.Username, avm.Password) == null)
            {
                return View("Login");
            }
            SessionPersister.Username = avm.Username;
            return View("Success");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}