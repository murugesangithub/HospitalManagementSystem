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
    public class AppointmentViewModel
    {
        [Required (ErrorMessage = "Patient Id is required")]
      [Display(Name = "Patient Id ")]     
        public string PatientId { get; set; }

        [Required(ErrorMessage = "PatientName is required")]
        [Display(Name = "Patient Name")]
        [DataType(DataType.Text)]
        public string PatientName { get; set; }

       

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
      
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Gender ")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string DateofBirth { get; set; }

        [Required]
        [Display(Name = "Date of Appointment ")]
        [DataType(DataType.Date)]
        public string DateofAppointment { get; set; }

        [Required(ErrorMessage = "Consulting Doctor is required")]
        [Display(Name = "Consulting Doctor ")]
        [DataType(DataType.Text)]
        public string ConsultingDoctor { get; set; }

     [Required]
     [Display(Name = "Time of Appointment ")]
      [DataType(DataType.Text)]
     public string TimeofAppointment { get; set; }

        [Required]
        [Display(Name = "Problem ")]
        [DataType(DataType.Text)]
        public string Problem { get; set; }

        [Required]
        [Display(Name = "Token Number ")]
        [DataType(DataType.Text)]
        public string TokenNumber{ get; set; }

        [Required(ErrorMessage = "Select your Time Slot")]
       // [Display(Name = "Time Slot")]
        //[DataType(DataType.Text)]
        public List<System.Web.Mvc.SelectListItem> TimeSlotList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int TimeSlot { get; set; }

        [Required(ErrorMessage = "Select your Department")]
       // [Display(Name = "Department")]
        //[DataType(DataType.Text)]
        public List<System.Web.Mvc.SelectListItem> DepartmentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Department { get; set; }

        public bool IsActive { get; set; }
    }
}