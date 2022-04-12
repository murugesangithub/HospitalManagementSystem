
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
        [Display(Name = "Hospital Id ")]
        public int HospitalId { get; set; }

        [Required]
        [Display(Name = "Contact No ")]
        public string ContactNo { get; set; }



        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }




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