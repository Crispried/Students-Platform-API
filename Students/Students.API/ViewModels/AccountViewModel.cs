﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Students.API.Models;
using Students.Domain.Entities;

namespace Students.API.ViewModels
{
    public class AccountViewModel
    {
        public User User { get; set; }
    }
}