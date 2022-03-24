using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientInquiryController : Controller
    {
        // GET: PatientInquiry
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> CountryList { get; private set; }
        public List<SelectListItem> GenderList { get; private set; }
        public ActionResult Add()
        {
            var ViewModel = new PatientInquiryViewModel();

            ViewModel.CountryList = GetCountryList();

            ViewModel.GenderList = GetGenderList();

            return View(ViewModel);

        }

        private List<SelectListItem> GetGenderList()
        {
            var genderSelectList = new List<SelectListItem>();
            var mastergenderRepository = new MasterGenderRepository();
            var genderList = mastergenderRepository.GetGenderList();

            foreach (var item in genderList)
            {
                genderSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.GenderId.ToString() });
            }
            return genderSelectList;
        }
        private List<SelectListItem> GetCountryList()
        {
            var countrySelectList = new List<SelectListItem>();
            var masterCountryRepository = new MasterCountryRepository();
            var countryList = masterCountryRepository.GetCountryList();

            foreach (var item in countryList)
            {
                countrySelectList.Add(new SelectListItem() { Text = item.Description, Value = item.CountryId.ToString() });
            }
            return countrySelectList;
        }

    }
}