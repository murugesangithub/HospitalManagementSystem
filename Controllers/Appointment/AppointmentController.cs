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
    public class AppointmentController : Controller
    {

        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> TimeSlotList { get; set; }
        public List<SelectListItem> GenderList { get; set; }

        public ActionResult Add()
        {


            var ViewModel = new AppointmentViewModel();

            ViewModel.DepartmentList = GetDepartmentList();
            var masterTimeSlotList = GetMasterTimeSlotList();
            ViewModel.TimeSlotListMorning = GetMorningTimeSlotList(masterTimeSlotList);
            ViewModel.TimeSlotListEvening = GetEveningTimeSlotList(masterTimeSlotList);
            ViewModel.GenderList = GetGenderList();
            return View(ViewModel);

        }
        public ActionResult AddAppointment(AppointmentViewModel model)
        {
            var appointmentRepository = new AppointmentRepository();
            if (model.TokenNumber == default(int))
            {
                appointmentRepository.AppointmentDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {
                appointmentRepository.AppointmentDetailUpdation(model);
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

        private List<SelectListItem> GetDepartmentList()
        {
            var departmentSelectList = new List<SelectListItem>();
            var masterdepartmentRepository = new MasterDepartmentRepository();
            var departmentList = masterdepartmentRepository.GetDepartmentList();

            foreach (var item in departmentList)
            {
                departmentSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.DepartmentId.ToString() });
            }
            return departmentSelectList;
        }


        private List<Entity.Master_TimeSlot> GetMasterTimeSlotList()
        {
            var timeslotSelectList = new List<SelectListItem>();
            var mastertimeslotRepository = new MasterTimeSlotRepository();
            var timeslotList = mastertimeslotRepository.GetTimeSlotList();

            return timeslotList;
        }
        private List<SelectListItem> GetMorningTimeSlotList(List<Entity.Master_TimeSlot> timeslotList)
        {
            var timeslotSelectList = new List<SelectListItem>();

            foreach (var item in timeslotList.Where(x => x.TimeSlotId <= 21))
            {
                timeslotSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TimeSlotId.ToString() });
            }
            return timeslotSelectList;
        }
        private List<SelectListItem> GetEveningTimeSlotList(List<Entity.Master_TimeSlot> timeslotList)
        {
            var timeslotSelectList = new List<SelectListItem>();
            foreach (var item in timeslotList.Where(x => x.TimeSlotId > 21))
            {
                timeslotSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TimeSlotId.ToString() });
            }
            return timeslotSelectList;
        }
        public ActionResult GetAppointmentList(JQGridSort jQGridSort)
        {
            var appointmentRepository = new AppointmentRepository();
            var result = appointmentRepository.GetAppointmentList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int tokenNumber)
        {
            var appointmentRepository = new AppointmentRepository();
            appointmentRepository.AppointmentDeletion(tokenNumber);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        public ActionResult UpdateAppointmentDetail(string id = null)
        {
            int tokenNumber = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out tokenNumber);
            }
            var model = new AppointmentViewModel();
            var appointmentRepository = new AppointmentRepository();
            model = appointmentRepository.GetAppointmentByAppointmentDetailId(tokenNumber);
            //model.DepartmentList = GetDepartmentList();
            var masterTimeSlotList = GetMasterTimeSlotList();
            model.TimeSlotListMorning = GetMorningTimeSlotList(masterTimeSlotList);
            model.TimeSlotListEvening = GetEveningTimeSlotList(masterTimeSlotList);
            model.GenderList = GetGenderList();

            return View(model);

        }
        //icon
        public ActionResult GetAppointmentDetail(string id)
        {
            int TokenNumber = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out TokenNumber);
            }
            var appointmentRepository = new AppointmentRepository();
            var result = appointmentRepository.GetAppointmentDetail(TokenNumber);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetAppointmentTimeDetailByDate(string date)
        {
            DateTime appointmentDate;
            DateTime.TryParse(date, out appointmentDate);
            var appointmentRepository = new AppointmentRepository();
            var result = appointmentRepository.GetAppointmentTimeDetailByDate(appointmentDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}