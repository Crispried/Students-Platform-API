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
            var Users = userRepository.Users;
            return View(Users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (userRepository.SaveUser(user))
            {
                return View("Index", userRepository.Users); // smth like return Json(new { result = "success" });
            }
            return View(); // smth like return Json(new { result = "error" });
        }

        [HttpGet]
        public ActionResult DeleteUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            if (userRepository.DeleteUser(userId))
            {
                return View("Index", userRepository.Users); // smth like return Json(new { result = "success" });
            }
            return View(); // smth like return Json(new { result = "error" });
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