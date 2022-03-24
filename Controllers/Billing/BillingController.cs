﻿using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var ViewModel = new BillingViewModel();
            return View(ViewModel);
        }
    }
}