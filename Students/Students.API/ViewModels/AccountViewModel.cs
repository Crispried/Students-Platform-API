﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.Domain.Entities;

namespace Students.API.ViewModels
{
    public class AccountViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}