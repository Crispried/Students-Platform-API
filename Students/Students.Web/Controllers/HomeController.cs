using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// DI using example. After creating constructor for repository
        /// you can use all methods in EFRepository
        /// </summary>
        private IUserRepository userRepository;

        public HomeController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}