﻿using System;
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
using System.Web.Http.Cors;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Students.API.APIControllers.Controllers
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody]JObject jsonData)
        {
            var user = jsonData.GetValue("user").ToString();
            var password = jsonData.GetValue("password").ToString();

            if (user == password)
            {
                string url = "http://authorization-server.azurewebsites.net/oauth2/token";
                var request = (HttpWebRequest)WebRequest.Create(url);

                var postData = "username=" + user;
                postData += "&password=" + password;
                postData += "&grant_type=password";
                postData += "&client_id=099153c2625149bc8ecb3e85e03f0022"; 

                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                Token token = JsonConvert.DeserializeObject<Token>(responseString);

                return Request.CreateResponse(HttpStatusCode.OK, token.access_token);
            }

            return Request.CreateResponse(HttpStatusCode.Forbidden);
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
                    return Request.CreateResponse(HttpStatusCode.OK);
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
