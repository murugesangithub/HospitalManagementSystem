
using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class PatientAdmissionRepository : BaseRepository
    {
        public void PatientAdmitFormInsertion(PatientAdmissionViewModel patientAdmissionViewModel)
        {
            //insert

            PatientAdmitForm patientAdmitForm = new PatientAdmitForm()
            {
                PatientAdmissionId = patientAdmissionViewModel.PatientAdmissionId,
                DoctorName = patientAdmissionViewModel.DoctorName,
                AdmissionDate = patientAdmissionViewModel.AdmissionDate,
                PlannedProcedure = patientAdmissionViewModel.PlannedProcedure,
                GuardianName = patientAdmissionViewModel.GuardianName,
                Email = patientAdmissionViewModel.Email,
                Address = patientAdmissionViewModel.Address,
                PhoneNumber = (int)Convert.ToInt64(patientAdmissionViewModel.PhoneNumber),
                City = patientAdmissionViewModel.City,
                State = patientAdmissionViewModel.State,
                PostalCode = patientAdmissionViewModel.PostalCode,
                ItemNumber = patientAdmissionViewModel.ItemNumber,
                MaritalStatus = patientAdmissionViewModel.MaritalStatus,
                Contact = patientAdmissionViewModel.Contact,
                DateofBirth = patientAdmissionViewModel.DateofBirth,
                Gender = patientAdmissionViewModel.Gender,
                PatientName = patientAdmissionViewModel.PatientName,
                PatientBelow18 = patientAdmissionViewModel.Patient,
                IsActive = true,
            };

            dbcontext.PatientAdmitForms.Add(patientAdmitForm);
            dbcontext.SaveChanges();



        }

        //select

        public JQGridResponse<PatientAdmissionViewModel> GetPatientAdmissionList(JQGridSort jQGridSort)
        {
            IQueryable<PatientAdmissionViewModel> list = GetPatientAdmissionListQuery();
            var predicate = JQGridSorting.GeneratePredicate<PatientAdmissionViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }



        public IQueryable<PatientAdmissionViewModel> GetPatientAdmissionListQuery()
        {
            var result = dbcontext.PatientAdmitForms.Where(x => x.IsActive).Select(s => new PatientAdmissionViewModel()
            {
                PatientAdmissionId = s.PatientAdmissionId,
                DoctorName = s.DoctorName,
                AdmissionDate = s.AdmissionDate,

                PlannedProcedure = s.PlannedProcedure,

                MaritalStatus = s.MaritalStatus,
                ItemNumber = s.ItemNumber,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Contact = s.Contact,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                PatientName = s.PatientName,
                Gender = s.Gender,
                Patient = s.PatientBelow18,
                IsActive = s.IsActive,

            }).ToList();

            result.ForEach(x => x.EncryptPatientAdmissionId = Cryptography.EncryptStringToBytes_Aes(x.PatientAdmissionId.ToString()));

            return result.AsQueryable();
        }


        //delete

        public void PatientAdmissionDeletion(int patientAdmissionId)
        {
            var patientAdmitForm = dbcontext.PatientAdmitForms.Where(x => x.IsActive && x.PatientAdmissionId == patientAdmissionId).FirstOrDefault();

            {
                patientAdmitForm.IsActive = false;
                dbcontext.Entry(patientAdmitForm);
                dbcontext.SaveChanges();
            }


        }

        public void PatientAdmissionUpdation(PatientAdmissionViewModel patientAdmissionViewModel)
        {
            var isPatientAdmitFormExist = dbcontext.PatientAdmitForms.Where(x => x.IsActive && x.PatientAdmissionId == patientAdmissionViewModel.PatientAdmissionId).FirstOrDefault();
            if (isPatientAdmitFormExist != null)
            {

                isPatientAdmitFormExist.DoctorName = patientAdmissionViewModel.DoctorName;
                isPatientAdmitFormExist.AdmissionDate = patientAdmissionViewModel.AdmissionDate;
                isPatientAdmitFormExist.GuardianName = patientAdmissionViewModel.GuardianName;
                isPatientAdmitFormExist.Email = patientAdmissionViewModel.Email;
                isPatientAdmitFormExist.Address = patientAdmissionViewModel.Address;
                isPatientAdmitFormExist.PatientBelow18 = patientAdmissionViewModel.Patient;
                isPatientAdmitFormExist.Contact = patientAdmissionViewModel.Contact;
                isPatientAdmitFormExist.PhoneNumber = (int)Convert.ToInt64(patientAdmissionViewModel.PhoneNumber);
                isPatientAdmitFormExist.City = patientAdmissionViewModel.City;
                isPatientAdmitFormExist.State = patientAdmissionViewModel.State;
                isPatientAdmitFormExist.PostalCode = patientAdmissionViewModel.PostalCode;
                isPatientAdmitFormExist.PlannedProcedure = patientAdmissionViewModel.PlannedProcedure;
                isPatientAdmitFormExist.MaritalStatus = patientAdmissionViewModel.MaritalStatus;
                isPatientAdmitFormExist.ItemNumber = patientAdmissionViewModel.ItemNumber;
                isPatientAdmitFormExist.DateofBirth = patientAdmissionViewModel.DateofBirth;
                isPatientAdmitFormExist.Gender = patientAdmissionViewModel.Gender;
                isPatientAdmitFormExist.PatientName = patientAdmissionViewModel.PatientName;
                isPatientAdmitFormExist.IsActive = true;

                dbcontext.Entry(isPatientAdmitFormExist);
                dbcontext.SaveChanges();
            }

        }

        public PatientAdmissionViewModel GetPatientAdmitedByPatientAdmissionId(int patientAdmissionId)
        {
            var result = dbcontext.PatientAdmitForms.Where(x => x.IsActive && x.PatientAdmissionId == patientAdmissionId).Select(s => new PatientAdmissionViewModel()
            {
                PatientAdmissionId = s.PatientAdmissionId,
                DoctorName = s.DoctorName,
                AdmissionDate = s.AdmissionDate,

                PlannedProcedure = s.PlannedProcedure,

                MaritalStatus = s.MaritalStatus,
                ItemNumber = s.ItemNumber,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Contact = s.Contact,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                PatientName = s.PatientName,
                Gender = s.Gender,
                Patient = s.PatientBelow18,
                IsActive = s.IsActive,

            }).FirstOrDefault();


            return result;
        }
        public PatientAdmissionViewModel GetPatientAdmissionDetail(int patientAdmissionId)
        {
            var result = dbcontext.PatientAdmitForms.Where(x => x.IsActive && x.PatientAdmissionId == patientAdmissionId).Select(s => new PatientAdmissionViewModel()
            {
                PatientAdmissionId = s.PatientAdmissionId,
                DoctorName = s.DoctorName,
                AdmissionDate = s.AdmissionDate,
                PlannedProcedure = s.PlannedProcedure,
                MaritalStatus = s.MaritalStatus,
                ItemNumber = s.ItemNumber,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Contact = s.Contact,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                PatientName = s.PatientName,
                Gender = s.Gender,
                Patient = s.PatientBelow18,
                IsActive = s.IsActive,

            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }



    }
}