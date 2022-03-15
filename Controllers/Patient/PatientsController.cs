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
    public class PatientsController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PatientInquiry()
        {
            var ViewModel = new PatientViewModel();

            ViewModel.MaritalStatusList = GetMaritalStatusList();

            ViewModel.CountryList = GetCountryList();

            ViewModel.GenderList = GetGenderList();

            return View(ViewModel);
           
        }
        public List<SelectListItem> MaritalStatusList { get; private set; }
        public List<SelectListItem> CountryList { get; private set; }
        public List<SelectListItem> GenderList { get; private set; }
        public ActionResult Add()
        {
            var ViewModel = new PatientViewModel();

            ViewModel.MaritalStatusList = GetMaritalStatusList();

            ViewModel.CountryList = GetCountryList();

            ViewModel.GenderList = GetGenderList();

            return View(ViewModel);
        }
        public ActionResult AddPatient(PatientViewModel model)
        {

            var patientRepository = new PatientRepository();
            if (model.PatientDetailId == default(int))
            {
                patientRepository.PatientDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {


                patientRepository.PatientDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }

            return View();
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

        private List<SelectListItem> GetMaritalStatusList()
        {
            var maritalstatusSelectList = new List<SelectListItem>();
            var mastermaritalstatusRepository = new MasterMaritalStatusRepository();
            var maritalstatusList = mastermaritalstatusRepository.GetMaritalStatusList();

            foreach (var item in maritalstatusList)
            {
                maritalstatusSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.MaritalStatusId.ToString() });
            }
            return maritalstatusSelectList;
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

        public ActionResult GetPatientsList(JQGridSort jQGridSort)
        {
            var patientRepository = new PatientRepository();
            var result = patientRepository.GetPatientsList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int patientDetailId)
        {
            var patientRepository = new PatientRepository();
            patientRepository.PatientsDeletion(patientDetailId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        public ActionResult UpdatePatientDetail(string id = null)
        {
            int patientDetailId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientDetailId);
            }

            var patientRepository = new PatientRepository();

            var model = patientRepository.GetPatientByPatientDetailId(patientDetailId) ?? new PatientViewModel();

            model.MaritalStatusList = GetMaritalStatusList();

            model.CountryList = GetCountryList();

            model.GenderList = GetGenderList();

            return View(model);

        }

    }


}