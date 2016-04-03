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
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(avm.Account.UserName)
             || string.IsNullOrEmpty(avm.Account.Password)
             || am.Login(avm.Account.UserName, avm.Account.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }
            SessionPersister.Username = avm.Account.UserName;
            return View("Success");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}