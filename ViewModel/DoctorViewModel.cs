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
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }


        // [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[Display(Name = "UserName")]
        //public string UserName { get; set; }


        /* [Required]
         [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "Password")]
        public string Password { get; set; }*/

        [Required]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        //[Required]
        //[Display(Name = "Code")]
        //public string Code { get; set; }

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
        [Display(Name = "State")]
        public List<System.Web.Mvc.SelectListItem> StateList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int State { get; set; }
        public string StateDesc { get; set; }

        [Required]
        [Display(Name = "City")]
        public List<System.Web.Mvc.SelectListItem> CityList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int City { get; set; }
        public string CityDesc { get; set; }

        public int DoctorDetailId { get; internal set; }
        public string EncryptDoctorDetailId { get; set; }
        public bool IsActive { get; set; }
    }
}