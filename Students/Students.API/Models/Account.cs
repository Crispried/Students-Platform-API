using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Students.API.Models
{
    public class Account : //Students.Domain.Entities.User
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}