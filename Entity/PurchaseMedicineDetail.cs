//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalManagementSystem.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PurchaseMedicineDetail
    {
        public int MedicineId { get; set; }
        public string SupplierName { get; set; }
        public string Code { get; set; }
        public System.DateTime Date { get; set; }
        public int Category { get; set; }
        public int Medicine { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int Discount { get; set; }
        public int GrandTotal { get; set; }
        public int PaymentType { get; set; }
        public int PaymentStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
