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
        [Required(ErrorMessage = "Doctor Name is required")]
        [Display(Name = "Doctor Name")]
        [DataType(DataType.Text)]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Admission Date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime AdmissionDate { get; set;}= DateTime.Now;

        [Required(ErrorMessage = "Planned Procedure is required")]
        [Display(Name = "Planned Procedure")]
        [DataType(DataType.Text)]
        public string PlannedProcedure { get; set; }

        [Required(ErrorMessage = "Item Number is required")]
        [Display(Name = "Item Number(S)")]
        [DataType(DataType.Text)]
        public string ItemNumber { get; set; }

        [Required(ErrorMessage = "Patient Name is required")]
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
        public int PhoneNumber { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime DateofBirth { get; set; } = DateTime.Now;

        public int PatientAdmissionId { get; set; }
        public bool IsActive { get; set; }
        public string EncryptPatientAdmissionId { get; set; }


    }
}