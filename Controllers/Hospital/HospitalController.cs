﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers.Hospital
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        public ActionResult hospital()
        {
            return View();
        }
    }
}