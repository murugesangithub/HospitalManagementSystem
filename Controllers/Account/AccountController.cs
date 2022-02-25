using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.Filter;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace HospitalManagementSystem.Controllers.Account
{
    //[Authorization]
    [ExceptionFilter]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var accountRepository = new AccountRepository();
            var result = accountRepository.LogOn(model.Email, model.Password);
            if (result != null)
            {
                HttpContext.Session[AppConstant.UserDetail] = result;
                return Redirect("Home/Index");


            }
            else
            {
                ModelState.AddModelError("", "Invalid Email and Password.");
                return View(model);
            }

        }


     
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.Session[AppConstant.UserDetail] = null;
            return RedirectToAction("Login", "Account");
        }
        [AllowAnonymous]
        public ActionResult Unauthorized()
        {
            return View();
        }


    }
}