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
    
    public partial class HospitalDetail
    {
        public int HospitalDetailId { get; set; }
        public string HospitalName { get; set; }
        public int HospitalId { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}