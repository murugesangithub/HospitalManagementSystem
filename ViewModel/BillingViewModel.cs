﻿using HospitalManagementSystem.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xunit;
namespace HospitalManagementSystem.ViewModel
{
    public class BillingViewModel
    {
        [Required]
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }

        [Required]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Required]
        [Display(Name = "Doctor Charges")]
        public string DoctorCharges { get; set; }

        [Required]
        [Display(Name = "Medicine Charges")]
        public string MedicineCharges { get; set; }

        [Required]
        [Display(Name = "Room Charges")]
        public string RoomCharges { get; set; }

        [Required(ErrorMessage = "Select your Department")]
        public List<System.Web.Mvc.SelectListItem> DepartmentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Department { get; set; }
        public string DepartmentDesc { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Admit Date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime AdmitDate { get; set; }= DateTime.Now;

        [Required]
        [Display(Name = "Discharge Date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DischargeDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Select your Department")]
        [Display(Name = "Service Name ")]
        public List<System.Web.Mvc.SelectListItem> ServiceList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Service { get; set; }
        public string ServiceDesc { get; set; }

        [Required]
        [Display(Name = "Cost of Treatment")]
        public string CostofTreatment { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be a number")]
        [Display(Name = "Discount (%)")]
        public string Discount { get; set; }

        [Required]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be a number")]
        [Display(Name = "Card/CheckNo")]
        public string CheckNo { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Must be a number")]
        [Display(Name = "Total Amount ")]
        public string TotalAmount { get; set; }

        [Required(ErrorMessage = "Select your PaymentMethod")]
        [Display(Name = "Payment Method ")]
        public List<System.Web.Mvc.SelectListItem> PaymentList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Payment { get; set; }
        public string PaymentMethod { get; set; }


        [Required(ErrorMessage = "Select your PaymentMethod")]
        [Display(Name = "Payment Method ")]
        public List<System.Web.Mvc.SelectListItem> PaymentStatusList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int PaymentStatus { get; set; }
        public string PaymentStatusMethod { get; set; }

        public int PatientId { get; set; }
        public string EncryptPatientId { get; set; }
        public bool IsActive { get; set; }
    }
}