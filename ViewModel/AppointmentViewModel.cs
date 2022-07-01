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

        [Required]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        public List<System.Web.Mvc.SelectListItem> GenderList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int? Gender { get; set; }
        public string GenderDescription { get; set; }

        [Required]
        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        public string Status { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Age")]
        [RegularExpression(@"^\S[0-9]{0,3}$", ErrorMessage = "Age must be a number")]
        public int? Age { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number only in 10 digits")]
        public string PhoneNumber { get; set; }

        //[Required]
        //[Display(Name = "Date of Birth")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        //public DateTime DateofBirth { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Appointment Date ")]
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateofAppointment { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Consulting Doctor ")]
        [DataType(DataType.Text)]
        public string ConsultingDoctor { get; set; }
       

        [Required]
        [Display(Name = "Appointment Time ")]
        [DataType(DataType.Text)]
        public string TimeofAppointment { get; set; } 


        [Required]
        [Display(Name = "Problem ")]
        [DataType(DataType.Text)]
        public string Problem { get; set; }

        /*[Required]
        [Display(Name = "Token Number ")]
        [DataType(DataType.Text)]
        public string TokenNumber { get; set; }*/

        [Required]
        public List<System.Web.Mvc.SelectListItem> TimeSlotListMorning { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public List<System.Web.Mvc.SelectListItem> TimeSlotListEvening { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int TimeSlot { get; set; }
        public string TimeSlotDesc { get; set; }

        [Required]
        public List<System.Web.Mvc.SelectListItem> DepartmentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Department { get; set; }
        public string DepartmentDesc { get; set; }

        [Required]
        public List<System.Web.Mvc.SelectListItem> DoctorList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public string DoctorListDesc { get; set; }

        public int TokenNumber { get; set; }
        public string EncryptTokenNumber { get; set; }
        public bool IsActive { get; set; }
        public int DoctorId { get; set; }
    }
}