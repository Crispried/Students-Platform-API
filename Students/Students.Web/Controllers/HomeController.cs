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
        /// Initializing repositories for working with context
        /// </summary>
        private IUserRepository userRepository;
        private IHousingAnnouncmentRepository housingAnnouncmentRepository;
        private ITravelAnnouncmentRepository travelAnnouncmentRepository;
        private IMarketAnnouncmentRepository marketAnnouncmentRepository;
        private IServiceAnnouncmentRepository serviceAnnouncmentRepository;     

        public HomeController(IUserRepository userRepository,
            IHousingAnnouncmentRepository housingAnnouncmentRepository,
            ITravelAnnouncmentRepository travelAnnouncmentRepository,
            IMarketAnnouncmentRepository marketAnnouncmentRepository,
            IServiceAnnouncmentRepository serviceAnnouncmentRepository)
        {
            this.userRepository = userRepository;
            this.housingAnnouncmentRepository = housingAnnouncmentRepository;
            this.travelAnnouncmentRepository = travelAnnouncmentRepository;
            this.marketAnnouncmentRepository = marketAnnouncmentRepository;
            this.serviceAnnouncmentRepository = serviceAnnouncmentRepository;
        }
        
        [HttpGet]
        public ActionResult Index()
        {            
            var Users = userRepository.Users;
            return View(Users);
        }

        #region demo part
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
        #endregion

        
    }
}