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
    
    public partial class PatientDetail
    {
        public int PatientDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string GuardianName { get; set; }
        public int MaritalStatus { get; set; }
        public int Age { get; set; }
        public string DateofBirth { get; set; }
        public string Problem { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int Country { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
    }
}
