
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
    public class PatientViewModel
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
        public int Age { get; set; }

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
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number only in 10 digits")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Select your Gender")]
        public List<System.Web.Mvc.SelectListItem> GenderList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Gender { get; set; }
        public string GenderDescription { get; set; }

        [Required]
        [Display(Name = "Date of Birth ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime DateofBirth { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Select your MaritalStatus")]
        public List<System.Web.Mvc.SelectListItem> MaritalStatusList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int MaritalStatus { get; set; }
        public string MaritalStatusDescription { get; set; }

        [Required(ErrorMessage = "Select your Country")]
        [Display(Name = "Country")]
        public List<System.Web.Mvc.SelectListItem> CountryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Country { get; set; }
        public string CountryDesc { get; set; }

        public bool IsActive { get; set; }

        public int PatientDetailId { get; set; }
        public string EncryptPatientDetailId { get; set; }
    }

}