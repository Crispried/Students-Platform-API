﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students.API.Controllers
{
    public class PrivateMessagesController : Controller
    {
        // GET: PrivateMessages
        public ActionResult Index()
        {
            return View();
        }
    }
}