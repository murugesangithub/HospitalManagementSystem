﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HMSEntities : DbContext
    {
        public HMSEntities()
            : base("name=HMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Master_Department> Master_Department { get; set; }
        public virtual DbSet<Master_TimeSlot> Master_TimeSlot { get; set; }
        public virtual DbSet<Master_Country> Master_Country { get; set; }
        public virtual DbSet<Master_MaritalStatus> Master_MaritalStatus { get; set; }
        public virtual DbSet<Master_Gender> Master_Gender { get; set; }
        public virtual DbSet<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual DbSet<PatientDetail> PatientDetails { get; set; }
        public virtual DbSet<DoctorDetail> DoctorDetails { get; set; }
        public virtual DbSet<Master_City> Master_City { get; set; }
        public virtual DbSet<Master_Specialist> Master_Specialist { get; set; }
        public virtual DbSet<Master_State> Master_State { get; set; }
    }
}
