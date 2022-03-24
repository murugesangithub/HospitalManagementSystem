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
    public class PatientAdmissionViewModel
    {


        [Required(ErrorMessage = "DoctorName is required")]
        [Display(Name = "Doctor Name")]
        [DataType(DataType.Text)]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Admission Date ")]
        [DataType(DataType.Date)]
        public string AdmissionDate { get; set; }

        [Required(ErrorMessage = "Planned Procedure is required")]
        [Display(Name = "Planned Procedure")]
        [DataType(DataType.Text)]
        public string PlannedProcedure { get; set; }

        [Required(ErrorMessage = "Item Number is required")]
        [Display(Name = "Item Number(S)")]
        [DataType(DataType.Text)]
        public string ItemNumber { get; set; }

        [Required(ErrorMessage = "PatientName is required")]
        [Display(Name = "Patient Name")]
        [DataType(DataType.Text)]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }


        [Required]
        [Display(Name = "Which one(s) do you prefer to be contacted by")]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "The patient under the age of 18 years?")]
        public string Patient { get; set; }

        [Required]
        [Display(Name = "Guardian Name ")]
        public string GuardianName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number only in 10 digits")]
        public string PhoneNumber { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\S[0-9]{0,6}$", ErrorMessage = "PostalCode must be a number")]
        public string PostalCode { get; set; }



        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public string DateofBirth { get; set; }



        public int PatientAdmissionId { get; set; }
        public bool IsActive { get; set; }
        public string EncryptPatientAdmissionId { get; set; }



        /*[Required(ErrorMessage = "Patient Id is required")]
        [Display(Name = "Patient Id ")]
        public string PatientId { get; set; }*/

        //[Required(ErrorMessage = "Select your Gender")]
        //public List<System.Web.Mvc.SelectListItem> GenderList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        //public int Gender { get; set; }
        //public string GenderDescription { get; set; }




        //[Required]
        //[DataType(DataType.Text)]
        //[Display(Name = "Age")]
        //[RegularExpression(@"^\S[0-9]{0,3}$", ErrorMessage = "Age must be a number")]
        //public string Age { get; set; }

        //[Required]
        //[Display(Name = "Address")]
        //public string Address { get; set; }




        //[Required]
        //[Display(Name = "Date of Appointment ")]
        //[DataType(DataType.Date)]
        //public string DateofAppointment { get; set; }





        //[Required]
        //[Display(Name = "Problem ")]
        //[DataType(DataType.Text)]
        //public string Problem { get; set; }

        /*[Required]
        [Display(Name = "Token Number ")]
        [DataType(DataType.Text)]
        public string TokenNumber { get; set; }*/

        //[Required(ErrorMessage = "Select your Time Slot")]       
        //public List<System.Web.Mvc.SelectListItem> TimeSlotList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        //public int TimeSlot { get; set; }
        //public string TimeSlotDesc { get; set; }


        //public int Department { get; set; }
        //public string DepartmentDesc { get; set; }

        //public int TokenNumber { get; set; }
        //public string EncryptTokenNumber { get; set; }

    }
}