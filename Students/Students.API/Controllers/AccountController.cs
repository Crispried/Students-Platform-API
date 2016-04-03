using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SessionSecurity.Models;
using SessionSecurity.Security;
using SessionSecurity.ViewModels;

namespace SessionSecurity.Controllers
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
            if (string.IsNullOrEmpty(avm.Account.Username)
             || string.IsNullOrEmpty(avm.Account.Password)
             || am.Login(avm.Account.Username, avm.Account.Password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }
            SessionPersister.Username = avm.Account.Username;
            return View("Success");
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}