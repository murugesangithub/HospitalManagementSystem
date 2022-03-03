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
        [DataType(DataType.Password)]
        [Display(Name = "Age")]
        public string Age { get; set; }

        [Required]
        //[Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Problem")]
        public string Problem { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Gender ")]
        public string Gender { get; set; }


        [Required]
        [Display(Name = "Date of Birth ")]
        [DataType(DataType.Date)]
        public string DateofBirth { get; set; }

        [Required]
        [Display(Name = "Country")]
        public List<System.Web.Mvc.SelectListItem> CoutryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Country { get; set; }

        [Display(Name = "Profile Image")]
        [AllowedFileExtension(".jpg", ".png", ".gif", ".jpeg", ".jfif")]
        public HttpPostedFileBase ImageFileUpload { get; set; }
        public string ProfileImage { get; set; } = string.Empty;

        public bool IsActive { get; set; }
      
        public object PatientDetailId { get; internal set; }
    }

}