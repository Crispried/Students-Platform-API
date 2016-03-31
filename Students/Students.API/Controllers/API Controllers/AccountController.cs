using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.API.APIControllers.Controllers
{
    public class AccountController : ApiController
    {
        private IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public IHttpActionResult GetUserById(int id)
        {
            if (id != 0)
            {
                User result = userRepository.GetUserById(id);
                if(result != null)
                {
                    return Json(new { result = result });
                }
                return Json(new { result = "Not found" });
            }
            return Json(new { result = "Request is 0" });
        }

        [HttpPost]
        public IHttpActionResult GetUserByUsername(string username)
        {
            if (username != null)
            {
                User result = userRepository.GetUserByUserName(username);
                if (result != null)
                {
                    return Json(new { result = result });
                }
                return Json(new { result = "Not found" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult GetUserByEmail(string email)
        {
            if (email != null)
            {
                User result = userRepository.GetUserByEmail(email);
                if (result != null)
                {
                    return Json(new { result = result });
                }
                return Json(new { result = "Not found" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult DeleteUser(int id)
        {
            if (id != 0)
            {
                if (userRepository.DeleteUser(id))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't delete" });
            }
            return Json(new { result = "Request is 0" });
        }

        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            if (user != null)
            {
                if (userRepository.SaveUser(user))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't add" });
            }
            return Json(new { result = "Request is null" });
        }

        [HttpPost]
        public IHttpActionResult EditUser(User user)
        {
            if (user != null)
            {
                if (userRepository.SaveUser(user))
                {
                    return Json(new { result = "Success" });
                }
                return Json(new { result = "Can't edit" });
            }
            return Json(new { result = "Request is null" });
        }
    }
}
