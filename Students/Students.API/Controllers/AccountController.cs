using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Students.API.Infrastructure;
using Students.API.Security;
using Students.API.ViewModels;
using Students.Domain.Concrete;
using Students.Domain.Entities;
using Students.Domain.ViewModel;
using Students.Domain.Abstract;

namespace Students.API.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("Login");
        }
    }
}