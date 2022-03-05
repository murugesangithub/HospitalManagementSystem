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
        /*[Required(ErrorMessage = "Patient Id is required")]
        [Display(Name = "Patient Id ")]
        public string PatientId { get; set; }*/

        [Required(ErrorMessage = "PatientName is required")]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        [RegularExpression(@"^\S[0-9]{0,3}$", ErrorMessage = "Age must be a number")]
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
        [RegularExpression(@"^[0-9]{10}$",ErrorMessage ="Phone number only in 10 digits")]
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
        public string TokenNumber { get; set; }

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