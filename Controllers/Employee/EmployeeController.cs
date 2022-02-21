using HospitalManagementSystem.JqGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GeEmployeeList(JQGridSort jQGridSort)
        {
            //var accountRepository = new AccountRepository();
            //var result = accountRepository.GetUserList(jQGridSort);

            var result = new JQGridResponse<Employee>()
            {
               
                page = 1,
                rows = new List<Employee>()
                {
                    new Employee()
                    {
                        Name ="Murugesan", 
                        Address ="Manaparai", 
                    }
                },
                _search = false, 
                records = 1,

            };



            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}