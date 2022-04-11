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
    public class PatientTreatmentViewModel
    {

        [Required(ErrorMessage = "Patient Name is required")]
        [Display(Name = "Patient Name")]
        [DataType(DataType.Text)]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Medicine Name is required")]
        [Display(Name = "Medicine Name")]
        [DataType(DataType.Text)]
        public string MedicineName { get; set; }


        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        [DataType(DataType.Text)]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Dosage Description is required")]
        [Display(Name = "Dosage Desc")]
        [DataType(DataType.Text)]
        public string DosageDesc { get; set; }

        [Required(ErrorMessage = "Remarks is required")]
        [Display(Name = "Remarks")]
        [DataType(DataType.Text)]
        public string Remarks { get; set; }

        [Required(ErrorMessage = "Room Type is required")]
        [Display(Name = "Room Type")]  
        public string RoomType { get; set; }

        [Required(ErrorMessage = "Room Price is required")]
        [Display(Name = "Room Price")]
        public string RoomPrice { get; set; }

        [Required(ErrorMessage = "Room Number is required")]
        [Display(Name = "Room Number")]
        public string RoomNumber { get; set; }

        public bool IsActive { get; set; }
    }
}