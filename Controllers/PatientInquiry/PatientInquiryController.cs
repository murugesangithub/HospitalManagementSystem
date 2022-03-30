using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.JqGrid;
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
        public ActionResult AddPatientInquiry(PatientInquiryViewModel model)
        {

            var patientInquiryRepository = new PatientInquiryRepository();
            if (model.PatientId == default(int))
            {
                patientInquiryRepository.PatientInquiryDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {

                patientInquiryRepository.PatientInquiryDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult UpdatePatientInquiryDetail(string id = null)
        {
            int patientId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var model = new PatientInquiryViewModel();
            var patientInquiryRepository = new PatientInquiryRepository();
            model = patientInquiryRepository.GetPatientInquiryByPatientInquiryDetailId(patientId);
            model.CountryList = GetCountryList();

            model.GenderList = GetGenderList();

            return View(model);

        }
        public ActionResult GetPatientInquiryList(JQGridSort jQGridSort)
        {
            var patientInquiryRepository = new PatientInquiryRepository();
            var result = patientInquiryRepository.GetPatientInquiryList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UpdatePatientInquiry(string id = null)
        {
            int patientId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var model = new PatientInquiryViewModel();
            var patientInquiryRepository = new PatientInquiryRepository();
            model = patientInquiryRepository.GetPatientInquiryByPatientInquiryDetailId(patientId);
            model.CountryList = GetCountryList();

            model.GenderList = GetGenderList();

            return View(model);

        }
        public ActionResult Delete(int patientId)
        {
            var patientInquiryRepository = new PatientInquiryRepository();
            patientInquiryRepository.PatientInquiryDeletion(patientId);
            return Json(new AjaxResponse() { IsSuccess = true });
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