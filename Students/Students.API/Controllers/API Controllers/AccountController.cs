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
using Newtonsoft.Json.Linq;

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
        public HttpResponseMessage GetUserById([FromBody]JObject jsonData)
        {
            var userId = Convert.ToInt32(jsonData.GetValue("userId"));
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
        public HttpResponseMessage GetUserByUsername([FromBody]JObject jsonData)
        {
            var username = jsonData.GetValue("username").ToString();
            if (!string.IsNullOrEmpty(username))
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
        public HttpResponseMessage GetUserByEmail([FromBody]JObject jsonData)
        {
            var email = Convert.ToString(jsonData.GetValue("email"));
            if (!string.IsNullOrEmpty(email))
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
        public HttpResponseMessage DeleteUser([FromBody]JObject jsonData)
        {
            var userId = Convert.ToInt32(jsonData.GetValue("userId"));
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
        public HttpResponseMessage AddUser([FromBody]JObject jsonData)
        {
            try
            {
                User user = jsonData.GetValue("user").ToObject<User>();
                if (user != null)
                {
                    if (userRepository.SaveUser(user))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        public HttpResponseMessage EditUser([FromBody]JObject jsonData)
        {
            try
            {
                User user = jsonData.GetValue("user").ToObject<User>();
                if (user != null)
                {
                    if (userRepository.SaveUser(user))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotModified);
                }
            }
            catch (NullReferenceException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
