using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Students.Domain.Abstract;
using Students.Domain.Entities;

namespace Students.API.Controllers
{
    public class AccountController : ApiController
    {
        private IUserRepository userRepository;
        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public string[] lol()
        {
            string[] test = { "string1", "string2", "string3" };
            return test;
        }
    }
}
