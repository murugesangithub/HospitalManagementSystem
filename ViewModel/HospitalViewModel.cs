
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
    public class HospitalViewModel
    {

        [Required]
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }

        [Required]
        [Display(Name = "Hospital Phone Number")]
        public string HospitalPhoneNumber { get; set; }


        [Required]
        [Display(Name = "Contact No ")]
        public string ContactNo { get; set; }



        [Required]
        [Display(Name = "Address")]

        public string Address { get; set; }

        [Required]
        [Display(Name = "State")]

        public string State { get; set; }


        [Required]
        [Display(Name = "City")]

        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]

        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Hospital Address")]

        public string HospitalAddress { get; set; }

        [Required]
        [Display(Name = "Chart Number")]

        public string ChartNumber { get; set; }

        //[Required(ErrorMessage = "Select your Country")]
        //[Display(Name = "Country")]
        //public List<System.Web.Mvc.SelectListItem> CountryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        //public int Country { get; set; }
        //public string CountryDesc { get; set; }

        [Required]
        [Display(Name = "Health Care Number")]
        public string HealthCareNumber { get; set; }

        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        public bool IsActive { get; set; }

        public int HospitalDetailId { get; set; }
        public string EncryptHospitalDetailId { get; set; }
    }

}