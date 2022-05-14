
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
    public class MedicineViewModel
    {

        [Required]
        [Display(Name = "Medicine Name")]
        public string MedicineName { get; set; }

        [Required]
        [Display(Name = "Company Name ")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Purchase Date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Expired Date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ExpiredDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Select your Catogory")]
        public List<System.Web.Mvc.SelectListItem> CategoryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Category { get; set; }
        public string CategoryDesc { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Stock must be a number")]
        [Display(Name = "Stock")]
        public string Stock { get; set; }

        public int MedicineId { get; set; }

        public string EncryptMedicineId { get; set; }
        public bool IsActive { get; set; }

    }

}