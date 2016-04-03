using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Students.Domain.Entities;

namespace Students.API.Models
{
    public class Account : User
    {
        //[Display(Name = "UserName")]
        //public string UserName { get; set; }

        //[Display(Name = "Password")]
        //public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}