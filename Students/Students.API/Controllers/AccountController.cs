using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.API.Security;
using Students.API.ViewModels;
using Students.Domain.Concrete;
using Students.Domain.Entities;

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

            if (string.IsNullOrEmpty(avm.User.UserName)
             || string.IsNullOrEmpty(avm.User.Password)
             || am.Login(avm.User.UserName, avm.User.Password) == null)
            {
                ViewBag.Error = "User's Invalid";
                return View("Index");
            }
            SessionPersister.Username = avm.User.UserName;
            return View("Success");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}