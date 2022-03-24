using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PurchaseMedicineController : Controller
    {
        // GET: PurchaseMedicine
        public ActionResult Index()
        {
            return View();
        }

            public ActionResult Purchase()
            {
            var ViewModel = new PurchaseMedicineViewModel();
            return View(ViewModel);
        }
        }
}