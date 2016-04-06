using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Students.Domain.Abstract;
using Students.Domain.Entities;
using Students.Domain.ViewModel;
using Students.API.Infrastructure;
using Students.API.Security;
using Students.API.ViewModels;

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
        public HttpResponseMessage Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName)
             || string.IsNullOrEmpty(user.Password)
             || userRepository.Login(user.UserName, user.Password) == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            SessionPersister.Username = user.UserName;

            return Request.CreateResponse(HttpStatusCode.Forbidden);
        }

        [HttpPost]
        public HttpResponseMessage Logout()
        {
            SessionPersister.Username = string.Empty;
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]       
        public HttpResponseMessage GetUserById(int userId)
        {
            if (userId != 0)
            {
                User user = userRepository.GetUserById(userId); 
                UserVM result = (UserVM)EntitiesFactory.GetViewModel(user, EntitiesTypes.User); 
                if(result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetUserByUsername(string username)
        {
            if (username != null)
            {
                User user = userRepository.GetUserByUserName(username);
                UserVM result = (UserVM)EntitiesFactory.GetViewModel(user, EntitiesTypes.User);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage GetUserByEmail(string email)
        {
            if (email != null)
            {
                User user = userRepository.GetUserByEmail(email);
                UserVM result = (UserVM)EntitiesFactory.GetViewModel(user, EntitiesTypes.User);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage DeleteUser(int userId)
        {
            if (userId != 0)
            {
                if (userRepository.DeleteUser(userId))
                {
                    Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage AddUser(User user)
        {
            if (user != null)
            {
                if (userRepository.SaveUser(user))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public HttpResponseMessage EditUser(User user)
        {
            if (user != null)
            {
                if (userRepository.SaveUser(user))
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
