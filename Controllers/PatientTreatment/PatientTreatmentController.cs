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
    public class PatientTreatmentController : Controller
    {
        // GET: PatientTreatment
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> MedicineList { get; private set; }
        public List<SelectListItem> RoomNumberList { get; private set; }
        public List<SelectListItem> RoomTypeList { get; private set; }

        public ActionResult Add()
        {
            var ViewModel = new PatientTreatmentViewModel();
            ViewModel.MedicineList = GetMedicineList();
            ViewModel.RoomNumberList = GetRoomNumberList();
            ViewModel.RoomTypeList = GetRoomTypeList();
            return View(ViewModel);
        }
        private List<SelectListItem> GetMedicineList()
        {
            var medicineSelectList = new List<SelectListItem>();
            var mastermedicineRepository = new MasterMedicineRepository();
            var medicineList = mastermedicineRepository.GetMedicineList();

            foreach (var item in medicineList)
            {
                medicineSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.MedicineId.ToString() });
            }
            return medicineSelectList;
        }
        private List<SelectListItem> GetRoomNumberList()
        {
            var roomnumberSelectList = new List<SelectListItem>();
            var masterroomnumberRepository = new MasterRoomNumberRepository();
            var roomnumberList = masterroomnumberRepository.GetRoomNumberList();

            foreach (var item in roomnumberList)
            {
                roomnumberSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.RoomNumberId.ToString() });
            }
            return roomnumberSelectList;
        }
        private List<SelectListItem> GetRoomTypeList()
        {
            var roomtypeSelectList = new List<SelectListItem>();
            var masterroomtypeRepository = new MasterRoomTypeRepository();
            var roomtypeList = masterroomtypeRepository.GetRoomTypeList();

            foreach (var item in roomtypeList)
            {
                roomtypeSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.RoomTypeId.ToString() });
            }
            return roomtypeSelectList;
        }
        public ActionResult AddPatientTreatment(PatientTreatmentViewModel model)
        {

            var patienttreatmentRepository = new PatientTreatmentRepository();
            if (model.PatientId == default(int))
            {
                patienttreatmentRepository.PatientTreatmentDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {
                patienttreatmentRepository.PatientTreatmentDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult GetPatientTreatmentList(JQGridSort jQGridSort)
        {
            var patienttreatmentRepository = new PatientTreatmentRepository();
            var result = patienttreatmentRepository.GetPatientTreatmentList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int patientId)
        {
            var patienttreatmentRepository = new PatientTreatmentRepository();
            patienttreatmentRepository.PatientTreatmentDeletion(patientId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }
        public ActionResult UpdatePatientTreatmentDetail(string id = null)
        {
            int patientId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var model = new PatientTreatmentViewModel();
            var patientTreatmentRepository = new PatientTreatmentRepository();

            model = patientTreatmentRepository.GetPatientTreatmentByPatientTreamentId(patientId);

           model.MedicineList = GetMedicineList();
            model.RoomNumberList = GetRoomNumberList();
           model.RoomTypeList = GetRoomTypeList();

            return View(model);

        }
        //icon
        public ActionResult GetPatientTreatmentDetail(string id)
        {
            int patientId = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var patientTreatmentRepository = new PatientTreatmentRepository();
            var result = patientTreatmentRepository.GetPatientTreatmentDetail(patientId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}