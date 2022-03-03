using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers.Doctor
{
    public class DoctorController : Controller
    {
        public List<SelectListItem> StateList { get; private set; }

        // GET: Doctor
        public ActionResult Add()
        {
            var viewmodel = new DoctorViewModel();

            viewmodel.GenderList = GetGenderList();
            viewmodel.RoleList = GetRoleList();
            viewmodel.StateList = GetStateList();
            viewmodel.CityList = GetCityList();


            return View(viewmodel);

        }


        private List<SelectListItem> GetGenderList()
        {
            var genderList = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Male", Value="M"},
                new SelectListItem(){ Text="FeMale", Value="F"},
                new SelectListItem(){ Text="Others", Value="O"},

            };
            return genderList;
        }


        private List<SelectListItem> GetRoleList()
        {
            var RoleList = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Please Select a Specialist:", Value="Speicalist"},
                new SelectListItem(){ Text="Anaesthesia", Value="Ana"},
                new SelectListItem(){ Text="Andrology", Value="Andro"},
                new SelectListItem(){ Text="Ayurvedic", Value="Ayur"},
                new SelectListItem(){ Text="Cardiologist", Value="Card"},
                new SelectListItem(){ Text="Densit", Value="Den"},
                new SelectListItem(){ Text="Dermatologist", Value="Derma"},
                new SelectListItem(){ Text="Dietician", Value="Diet"},
                new SelectListItem(){ Text="Endocrinologist", Value="Endo"},
                new SelectListItem(){ Text="ENT", Value="E"},
                new SelectListItem(){ Text="Medicine", Value="Medi"},
                new SelectListItem(){ Text="Nephrologist", Value="Nep"},
                new SelectListItem(){ Text="Homoeopathy", Value="Hemo"},
                new SelectListItem(){ Text="Neurologist", Value="Neuro"},

            };
            return RoleList;
        }



        private List<SelectListItem> GetStateList()
        {
            var StateList = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Please Select a State:", Value="State"},
                new SelectListItem(){ Text="Arunachal Pradesh", Value="Aruna"},
                new SelectListItem(){ Text="Assam", Value="A"},
                new SelectListItem(){ Text="Bihar", Value="Bi"},
                new SelectListItem(){ Text="Delhi", Value="Del"},
                new SelectListItem(){ Text="Goa", Value="G"},
                new SelectListItem(){ Text="Gujarat", Value="Guj"},
                new SelectListItem(){ Text="Haryana", Value="Har"},
                new SelectListItem(){ Text="Himachal Pradesh", Value="Him"},
                new SelectListItem(){ Text="Jammu and Kashmir", Value="Jam"},
                new SelectListItem(){ Text="Jharkhand", Value="Jar"},
                new SelectListItem(){ Text="Karnataka", Value="Karna"},
                new SelectListItem(){ Text="Kerala", Value="Ker"},
                new SelectListItem(){ Text="Maharashtra", Value="Mahara"},

            };
            return StateList;
        }



        private List<SelectListItem> GetCityList()
        {
            var CityList = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="Please Select a City:", Value="State"},
                new SelectListItem(){ Text="Karad", Value="Kar"},
                new SelectListItem(){ Text="Mumbai", Value="Mum"},
                new SelectListItem(){ Text="Nagpur", Value="Nag"},
                new SelectListItem(){ Text="Nashik", Value="Nas"},
                new SelectListItem(){ Text="Navi Mumbai", Value="Navi"},
                new SelectListItem(){ Text="Pune", Value="Pun"},
                new SelectListItem(){ Text="Thane", Value="Tha"},
               
            };
            return CityList;
        }

    }
}