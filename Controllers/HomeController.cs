using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: common/Home
        public ActionResult Index()
        {
            var ViewModel = new AppointmentViewModel();

            ViewModel.DepartmentList = GetDepartmentList();
            var masterTimeSlotList = GetMasterTimeSlotList();
            ViewModel.TimeSlotListMorning = GetTimeSlotList(masterTimeSlotList);
            ViewModel.DoctorList = GetDoctorList();
            //ViewModel.TimeSlotListMorning = GetMorningTimeSlotList(masterTimeSlotList);
            //ViewModel.TimeSlotListEvening = GetEveningTimeSlotList(masterTimeSlotList);
            //ViewModel.GenderList = GetGenderList();
            return View(ViewModel);
          

        }
        public ActionResult AddAppointment(AppointmentViewModel model)
        {
            var appointmentRepository = new AppointmentRepository();
            if (model.TokenNumber == default(int))
            {
                appointmentRepository.AppointmentDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
            }
            else
            {
                appointmentRepository.AppointmentDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
            }
            return RedirectToAction("Index");
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


        private List<SelectListItem> GetTimeSlotList(List<Entity.Master_TimeSlot> timeslotList)
        {
            var timeslotSelectList = new List<SelectListItem>();

            foreach (var item in timeslotList)
            {
                timeslotSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.TimeSlotId.ToString() });
            }
            return timeslotSelectList;
        }


        private List<SelectListItem> GetDoctorList()
        {
            var doctorSelectList = new List<SelectListItem>();
            var _doctorRepository = new DoctorRepository();
            var doctorList = _doctorRepository.GetDoctorListForDropDown();

            foreach (var item in doctorList)
            {
                doctorSelectList.Add(new SelectListItem() { Text = item.FirstName + " " + item.LastName, Value = item.EncryptDoctorDetailId });
            }
            return doctorSelectList;
        }

    }
}