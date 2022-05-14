

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
    public class PatientInquiryViewModel
    {

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Guardian Name ")]
        public string GuardianName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Age")]
        [RegularExpression(@"^\S[0-9]{0,3}$", ErrorMessage = "Age must be a number")]
        public string Age { get; set; }

        [Required]
        //[Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\S[0-9]{0,6}$", ErrorMessage = "PostalCode must be a number")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Problem")]
        public string Problem { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Height")]
        public string Height { get; set; }

        [Required]
        [Display(Name = "Diabetes or Blood sugar Problem ")]
        public string Diabetes { get; set; }

        [Required]
        [Display(Name = "Previous History of Cancer ")]
        public string Cancer { get; set; }

        [Required]
        [Display(Name = " Do you Smoke")]
        public string Doyousmoke { get; set; }

        [Required]
        [Display(Name = " Do you Drink Alchocol")]
        public string Doyoudrinkalchocol { get; set; }

        [Required]
        [Display(Name = "Thyroid problems")]
        public string ThyroidProblems { get; set; }

        [Required]
        [Display(Name = "Heart problems")]
        public string HeartProblems { get; set; }

        [Required]
        [Display(Name = "Lung problems")]
        public string LungProblems { get; set; }

        [Required]
        [Display(Name = "Blood Pressure problems")]
        public string BloodPressureProblems { get; set; }

        [Required]
        [Display(Name = "Kidney or Liver problems")]
        public string KidneyorLiverProblems { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public string Weight { get; set; }

        [Required]
        [Display(Name = "Do you have any medical " +
            "conditions not mentined above")]
        public string MedicalConditions { get; set; }

        [Required]
        [Display(Name = "Do you have any allergies to food, drugs, etc?")]
        public string Allergy { get; set; }

        [Required]
        [Display(Name = "If yes, when was your last dose?")]
        public string Lastdose { get; set; }

        [Display(Name = "Attach Medical Documents")]
        [AllowedFileExtension(".jpg", ".png", ".gif", ".jpeg", ".jfif")]
        public HttpPostedFileBase AttachFile { get; set; }
        public string AttachFileImage { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]       
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Select your Gender")]
        public List<System.Web.Mvc.SelectListItem> GenderList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Gender { get; set; }
        public string GenderDescription { get; set; }

        [Required]
        [Display(Name = "Date of Birth ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]   
        public DateTime DateofBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Select your Country")]
        [Display(Name = "Country")]
        public List<System.Web.Mvc.SelectListItem> CountryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Country { get; set; }
        public string CountryDesc { get; set; }
       
        public int PatientId { get; set; }
        public string EncryptPatientId { get; set; }
        public bool IsActive { get; set; }
    }

}