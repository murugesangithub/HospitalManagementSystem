using HospitalManagementSystem.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;
namespace HospitalManagementSystem.ViewModel
{
    public class PatientTreatmentViewModel
    {

        [Required(ErrorMessage = "Patient Name is required")]
        [Display(Name = "Patient Name")]
        [DataType(DataType.Text)]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Select your Medicine Name")]
        public List<System.Web.Mvc.SelectListItem> MedicineList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int MedicineName { get; set; }
        public string MedicineNameDescription { get; set; }


        [Required(ErrorMessage = "No of Days is required")]
        [Display(Name = "No of Days")]
        [DataType(DataType.Text)]
        public string Noofdays { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [DataType(DataType.Text)]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Dosage Description is required")]
        [Display(Name = "Dosage Desc")]
        [DataType(DataType.Text)]
        public string DosageDesc { get; set; }

        [Required(ErrorMessage = "Remarks is required")]
        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Select your Room Number")]
        public List<System.Web.Mvc.SelectListItem> RoomNumberList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int RoomNumber { get; set; }
        public string RoomNumberDescription { get; set; }

        [Required(ErrorMessage = "Room Price is required")]
        [Display(Name = "Room Price")]
        public string RoomPrice { get; set; }

        [Required(ErrorMessage = "Select your RoomType")]
        public List<System.Web.Mvc.SelectListItem>RoomTypeList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int RoomType { get; set; }
        public string RoomTypeDescription { get; set; }

        public int PatientId { get; set; }
        public string EncryptPatientId { get; set; }

        public bool IsActive { get; set; }
    }
}