using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.API.Security;
using Students.API.ViewModels;
using Students.Domain.Concrete;

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
            var am = new EFUserRepository();

            if (am.Login(avm.Username, avm.Password))
            {
                SessionPersister.Username = avm.Username;
                return View("Success");
            }
            ViewBag.Error = "User's Invalid";
            return View("Login");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}