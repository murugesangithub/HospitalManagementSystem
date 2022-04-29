using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.JqGrid;
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

        public ActionResult Index()
        {

            return View();
        }
        public List<SelectListItem> StateList { get; private set; }
        public List<SelectListItem> CityList { get; private set; }
        public List<SelectListItem> SpecialistList { get; private set; }
        public List<SelectListItem> GenderList { get; private set; }
        public List<SelectListItem> HospitalNameList { get; private set; }
        // GET: Doctor
        public ActionResult Add()
        {
            var viewmodel = new DoctorViewModel();

            viewmodel.GenderList = GetGenderList();
            viewmodel.StateList = GetStateList();
            viewmodel.CityList = GetCityList();
            viewmodel.HospitalNameList = GetHospitalNameList();
            viewmodel.SpecialistList = GetSpecialistList();
            return View(viewmodel);
        }
        public ActionResult AddDoctor(DoctorViewModel model)
        {
            var doctorRepository = new DoctorRepository();
            if (model.DoctorDetailId == default(int))
            {
                doctorRepository.DoctorDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {
                doctorRepository.DoctorDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");

            }
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

        private List<SelectListItem> GetStateList()
        {
            var stateSelectList = new List<SelectListItem>();

            var masterStateRepository = new MasterStateRepository();
            var stateList = masterStateRepository.GetStatelist();

            foreach (var item in stateList)
            {
                stateSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.StateId.ToString() });
            }

            return stateSelectList;
        }
        private List<SelectListItem> GetHospitalNameList()
        {
            var hospitalnameSelectList = new List<SelectListItem>();

            var masterhospitalRepository = new MasterHospitalRepository();
            var hospitalnameList = masterhospitalRepository.GetHospitalNameList();

            foreach (var item in hospitalnameList)
            {
                hospitalnameSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.HospitalId.ToString() });
            }

            return hospitalnameSelectList;
        }
        private List<SelectListItem> GetCityList()
        {
            var citySelectList = new List<SelectListItem>();

            var mastercityRepository = new MasterCityRepository();
            var cityList = mastercityRepository.GetCitylist();

            foreach (var item in cityList)
            {
                citySelectList.Add(new SelectListItem() { Text = item.Description, Value = item.CityId.ToString() });
            }

            return citySelectList;
        }

        private List<SelectListItem> GetSpecialistList()
        {
            var specialistSelectList = new List<SelectListItem>();

            var masterspecialistRepository = new MasterSpecialistRepository();
            var specialistList = masterspecialistRepository.GetSpecialistlist();

            foreach (var item in specialistList)
            {
                specialistSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.SpecialistId.ToString() });
            }

            return specialistSelectList;
        }
        public ActionResult GetDoctorList(JQGridSort jQGridSort)
        {
            var doctorRepository = new DoctorRepository();
            var result = doctorRepository.GetDoctorList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int doctorDetailId)
        {
            var doctorRepository = new DoctorRepository();
            doctorRepository.doctorDeletion(doctorDetailId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }
        //update
        public ActionResult UpdateDoctorDetail(string id = null)
        {
            int doctorDetailId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out doctorDetailId);
            }
            var model = new DoctorViewModel();
            var doctorRepository = new DoctorRepository();
          model = doctorRepository.GetDoctorDetailByDoctorDetailId(doctorDetailId);
            model.GenderList = GetGenderList();
            model.StateList = GetStateList();
            model.CityList = GetCityList();
            model.SpecialistList = GetSpecialistList();
            return View(model);
        }
        //icon
        public ActionResult GetDoctorDetail(string id)
        {
            int doctorDetailId = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out doctorDetailId);
            }
            var doctorRepository = new DoctorRepository();
            var result = doctorRepository.GetDoctorDetail(doctorDetailId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}