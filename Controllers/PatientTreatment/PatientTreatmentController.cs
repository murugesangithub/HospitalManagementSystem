using HospitalManagementSystem.DataAccess.Repository;
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
                roomnumberSelectList.Add(new SelectListItem() { Text = item.RoomNumber, Value = item.RoomNumberId.ToString() });
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
                roomtypeSelectList.Add(new SelectListItem() { Text = item.RoomType, Value = item.RoomTypeId.ToString() });
            }
            return roomtypeSelectList;
        }

    }
}