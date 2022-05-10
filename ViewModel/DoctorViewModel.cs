using HospitalManagementSystem.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HospitalManagementSystem;
using System.Web.Mvc;


namespace HospitalManagementSystem.ViewModel
{
    public class DoctorViewModel
    {


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        // [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number only in 10 digits")]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }



        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Specialist in")]
        public List<System.Web.Mvc.SelectListItem> SpecialistList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Specialist { get; set; }
        public string SpecialistDesc { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public List<System.Web.Mvc.SelectListItem> GenderList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Gender { get; set; }
        public string GenderDesc { get; set; }

        [Required]
        [Display(Name = "HospitalName")]
        public List<System.Web.Mvc.SelectListItem> HospitalNameList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int HospitalName { get; set; }
        public string HospitalNameDesc { get; set; }


        [Required]
        [Display(Name = "State")]
        public List<System.Web.Mvc.SelectListItem> StateList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int State { get; set; }
        public string StateDesc { get; set; }

        [Required]
        [Display(Name = "City")]
        public List<System.Web.Mvc.SelectListItem> CityList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int City { get; set; }
        public string CityDesc { get; set; }

        [Display(Name = "Profile Image")]
        [AllowedFileExtension(".jpg", ".png", ".gif", ".jpeg", ".jfif")]
        public HttpPostedFileBase ImageFileUpload { get; set; }
        public string ProfileImage { get; set; } = string.Empty;

        public int DoctorDetailId { get; set; }
        public string EncryptDoctorDetailId { get; set; }
        public bool IsActive { get; set; }
    }
}