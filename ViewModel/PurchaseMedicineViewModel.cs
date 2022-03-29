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
    public class PurchaseMedicineViewModel
    {
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Must be a number")]
        [Display(Name = "Code ")]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = " Date ")]
        [DataType(DataType.Date)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Select your Catogory")]
        public List<System.Web.Mvc.SelectListItem> CategoryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Category { get; set; }
        public string CategoryDesc { get; set; }

        [Required(ErrorMessage = "Select your Medicine")]
        public List<System.Web.Mvc.SelectListItem> MedicineList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Medicine { get; set; }
        public string MedicineDesc { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Must be a number")]
        [Display(Name = "Quantity ")]
        public string Quantity { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be a number")]
        [Display(Name = "Discount ")]
        public string Discount { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Must be a number")]
        [Display(Name = "Grand Total ")]
        public string GrandTotal { get; set; }

        [Display(Name = "Notes ")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Select your Payment Method")]
        [Display(Name = "Payment Type ")]
        public List<System.Web.Mvc.SelectListItem> PaymentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Payment { get; set; }
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Select your Payment Status")]
        [Display(Name = "Payment Status Method ")]
        public List<System.Web.Mvc.SelectListItem> PaymentStatusList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int PaymentStatus { get; set; }
        public string PaymentStatusMethod { get; set; }


        public bool IsActive { get; set; }
    }
}