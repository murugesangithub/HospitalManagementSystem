using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class PatientRepository : BaseRepository
    {
        //insert
        public void PatientDetailInsertion(PatientViewModel patientViewModel)
        {
            PatientDetail patientDetail = new PatientDetail()
            {
                PatientDetailId = patientViewModel.PatientDetailId,
                FirstName = patientViewModel.FirstName,
                LastName = patientViewModel.LastName,
                GuardianName = patientViewModel.GuardianName,
                Email = patientViewModel.Email,
                Address = patientViewModel.Address,
                //Age = Convert.ToInt32(patientViewModel.Age),
                Age = patientViewModel.Age,
                PhoneNumber = patientViewModel.PhoneNumber,
                City = patientViewModel.City,
                State = patientViewModel.State,
                PostalCode = patientViewModel.PostalCode,
                Country = patientViewModel.Country,
                MaritalStatus = patientViewModel.MaritalStatus,
                Problem = patientViewModel.Problem,
                DateofBirth = patientViewModel.DateofBirth,
                Gender = patientViewModel.Gender,
                IsActive = true,
            };
            dbcontext.PatientDetails.Add(patientDetail);
            dbcontext.SaveChanges();
        }
        //update
        public void PatientDetailUpdation(PatientViewModel patientViewModel)
        {
            var isPatientDetailExist = dbcontext.PatientDetails.Where(x => x.IsActive && x.PatientDetailId == patientViewModel.PatientDetailId).FirstOrDefault();
            if (isPatientDetailExist != null)
            {
                isPatientDetailExist.FirstName = patientViewModel.FirstName;
                isPatientDetailExist.LastName = patientViewModel.LastName;
                isPatientDetailExist.GuardianName = patientViewModel.GuardianName;
                isPatientDetailExist.Email = patientViewModel.Email;
                isPatientDetailExist.Address = patientViewModel.Address;
                //isPatientDetailExist.Age = Convert.ToInt32(patientViewModel.Age);
                isPatientDetailExist.Age = patientViewModel.Age;
                isPatientDetailExist.PhoneNumber = patientViewModel.PhoneNumber;
                isPatientDetailExist.City = patientViewModel.City;
                isPatientDetailExist.State = patientViewModel.State;
                isPatientDetailExist.PostalCode = patientViewModel.PostalCode;
                isPatientDetailExist.Country = patientViewModel.Country;
                isPatientDetailExist.MaritalStatus = patientViewModel.MaritalStatus;
                isPatientDetailExist.Problem = patientViewModel.Problem;
                isPatientDetailExist.DateofBirth = patientViewModel.DateofBirth;
                isPatientDetailExist.Gender = patientViewModel.Gender;
                isPatientDetailExist.IsActive = true;
                dbcontext.Entry(isPatientDetailExist);
                dbcontext.SaveChanges();
            }
        }
        //select
        public JQGridResponse<PatientViewModel> GetPatientsList(JQGridSort jQGridSort)
        {
            IQueryable<PatientViewModel> list = GetPatientsListQuery();
            var predicate = JQGridSorting.GeneratePredicate<PatientViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<PatientViewModel> GetPatientsListQuery()
        {
            var result = dbcontext.PatientDetails.Where(x => x.IsActive).Select(s => new PatientViewModel()
            {
                PatientDetailId = s.PatientDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                MaritalStatusDescription = dbcontext.Master_MaritalStatus.Where(x => x.MaritalStatusId == s.MaritalStatus).Select(b => b.Description).FirstOrDefault(),
                MaritalStatus = s.MaritalStatus,
                //Age = s.Age.ToString(),
                Age = s.Age,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                IsActive = s.IsActive,
            }).ToList();
            result.ForEach(x => x.EncryptPatientDetailId = Cryptography.EncryptStringToBytes_Aes(x.PatientDetailId.ToString()));
            return result.AsQueryable();
        }
        public PatientViewModel GetPatientByPatientDetailId(int patientDetailId)
        {
            var result = dbcontext.PatientDetails.Where(x => x.IsActive && x.PatientDetailId == patientDetailId).Select(s => new PatientViewModel()
            {
                PatientDetailId = s.PatientDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                MaritalStatusDescription = dbcontext.Master_MaritalStatus.Where(x => x.MaritalStatusId == s.MaritalStatus).Select(b => b.Description).FirstOrDefault(),
                MaritalStatus = s.MaritalStatus,
                Age = s.Age,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                IsActive = s.IsActive,
            }).FirstOrDefault();
            return result;
        }
        //delete
        public void PatientsDeletion(int patientDetailId)
        {
            var patientdetail = dbcontext.PatientDetails.Where(x => x.IsActive && x.PatientDetailId == patientDetailId).FirstOrDefault();
            if (patientdetail != null)
            {
                patientdetail.IsActive = false;
                dbcontext.Entry(patientdetail);
                dbcontext.SaveChanges();
            }
        }
        //icon
        public PatientViewModel GetPatientDetail(int patientDetailId)
        {
            var result = dbcontext.PatientDetails.Where(x => x.IsActive && x.PatientDetailId == patientDetailId).Select(s => new PatientViewModel()
            {
                PatientDetailId = s.PatientDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                MaritalStatusDescription = dbcontext.Master_MaritalStatus.Where(x => x.MaritalStatusId == s.MaritalStatus).Select(b => b.Description).FirstOrDefault(),
                MaritalStatus = s.MaritalStatus,
                Age = s.Age,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Problem = s.Problem,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Address = s.Address,
                City = s.City,
                PostalCode = s.PostalCode,
                State = s.State,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                IsActive = s.IsActive,
            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }
    }
}