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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public List<System.Web.Mvc.SelectListItem> CategoryList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Category { get; set; }
        public string CategoryDesc { get; set; }

        [Required]
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

        [Required]
        [Display(Name = "Notes ")]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Payment Type ")]
        public List<System.Web.Mvc.SelectListItem> PaymentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Payment { get; set; }
        public string PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Payment Status Method ")]
        public List<System.Web.Mvc.SelectListItem> PaymentStatusList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int PaymentStatus { get; set; }
        public string PaymentStatusMethod { get; set; }
        public int MedicineId { get; set; }

        public string EncryptMedicineId { get; set; }
        public bool IsActive { get; set; }
    }
}