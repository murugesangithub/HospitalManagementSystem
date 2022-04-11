using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class PatientInquiryRepository : BaseRepository
    {

        //insert
        public void PatientInquiryDetailInsertion(PatientInquiryViewModel patientInquiryViewModel)
        {
                PatientInquiryDetailForm patientInquiryDetailForm = new PatientInquiryDetailForm()
                {
                    PatientId= patientInquiryViewModel.PatientId,
                    FirstName = patientInquiryViewModel.FirstName,
                    LastName = patientInquiryViewModel.LastName,
                    Email = patientInquiryViewModel.Email,
                   DateofBirth= patientInquiryViewModel.DateofBirth,
                    Age = Convert.ToInt32(patientInquiryViewModel.Age),
                    PhoneNumber = (int)Convert.ToInt64(patientInquiryViewModel.PhoneNumber),
                    Height= (int)Convert.ToInt64(patientInquiryViewModel.Height),
                    Weight = (int)Convert.ToInt64(patientInquiryViewModel.Weight),
                    GuardianName= patientInquiryViewModel.GuardianName,
                    Problem= patientInquiryViewModel.Problem,
                    Gender = Convert.ToInt32(patientInquiryViewModel.Gender),
                    Address = patientInquiryViewModel.Address,
                    City = patientInquiryViewModel.City,
                    State= patientInquiryViewModel.State,
                    Country = patientInquiryViewModel.Country,
                    PostalCode = (int)Convert.ToInt64(patientInquiryViewModel.PostalCode),
                    Diabetes= patientInquiryViewModel.Diabetes,
                   ThyroidProblems = patientInquiryViewModel.ThyroidProblems,
                    LungProblems = patientInquiryViewModel.LungProblems,
                   HeartProblems= patientInquiryViewModel.HeartProblems,
                   BloodProblems = patientInquiryViewModel.BloodPressureProblems,
                   Kidney = patientInquiryViewModel.KidneyorLiverProblems,
                    Cancer = patientInquiryViewModel.Cancer,
                    Smoke = patientInquiryViewModel.Doyousmoke,
                    Alchocol = patientInquiryViewModel.Doyoudrinkalchocol,
                   MedicalConditions= patientInquiryViewModel.MedicalConditions,
                    Allergy= patientInquiryViewModel.Allergy,
                   LastDose= patientInquiryViewModel.Lastdose,
                    MedicalDocuments = patientInquiryViewModel.AttachFileImage,
                    IsActive = true,
                };

                dbcontext.PatientInquiryDetailForms.Add(patientInquiryDetailForm);
                dbcontext.SaveChanges();
        }
        public void PatientInquiryDetailUpdation(PatientInquiryViewModel patientinquiryViewModel)
        {
            var isPatientInquiryDetailExist = dbcontext.PatientInquiryDetailForms.Where(x => x.IsActive && x.PatientId == patientinquiryViewModel.PatientId).FirstOrDefault();
            if (isPatientInquiryDetailExist != null)
            {
                isPatientInquiryDetailExist.PatientId = patientinquiryViewModel.PatientId;
                isPatientInquiryDetailExist.FirstName = patientinquiryViewModel.FirstName;
                isPatientInquiryDetailExist.LastName = patientinquiryViewModel.LastName;
                isPatientInquiryDetailExist.Email = patientinquiryViewModel.Email;
                isPatientInquiryDetailExist.Address = patientinquiryViewModel.Address;
                isPatientInquiryDetailExist.Age = Convert.ToInt32(patientinquiryViewModel.Age);
                isPatientInquiryDetailExist.PhoneNumber = (int)Convert.ToInt64(patientinquiryViewModel.PhoneNumber);
                isPatientInquiryDetailExist.GuardianName = patientinquiryViewModel.GuardianName;
                isPatientInquiryDetailExist.Country = patientinquiryViewModel.Country;
                isPatientInquiryDetailExist.Gender = patientinquiryViewModel.Gender;
                isPatientInquiryDetailExist.City = patientinquiryViewModel.City;
                isPatientInquiryDetailExist.State = patientinquiryViewModel.State;
                isPatientInquiryDetailExist.PostalCode = (int)Convert.ToInt64(patientinquiryViewModel.PostalCode);               
                isPatientInquiryDetailExist.Problem = patientinquiryViewModel.Problem;
                isPatientInquiryDetailExist.Weight = (int)Convert.ToInt64(patientinquiryViewModel.Weight);
                isPatientInquiryDetailExist.Height = (int)Convert.ToInt64(patientinquiryViewModel.Height);
                isPatientInquiryDetailExist.Diabetes = patientinquiryViewModel.Diabetes;
                isPatientInquiryDetailExist.Cancer = patientinquiryViewModel.Cancer;
                isPatientInquiryDetailExist.Alchocol = patientinquiryViewModel.Doyoudrinkalchocol;
                isPatientInquiryDetailExist.ThyroidProblems = patientinquiryViewModel.ThyroidProblems;
                isPatientInquiryDetailExist.HeartProblems = patientinquiryViewModel.HeartProblems;
                isPatientInquiryDetailExist.LungProblems = patientinquiryViewModel.LungProblems;
                isPatientInquiryDetailExist.BloodProblems = patientinquiryViewModel.BloodPressureProblems;
                isPatientInquiryDetailExist.Kidney = patientinquiryViewModel.KidneyorLiverProblems;
              
                isPatientInquiryDetailExist.MedicalConditions = patientinquiryViewModel.MedicalConditions;
                isPatientInquiryDetailExist.Allergy = patientinquiryViewModel.Allergy;
                isPatientInquiryDetailExist.LastDose = patientinquiryViewModel.Lastdose;
                isPatientInquiryDetailExist.IsActive = true;

                dbcontext.Entry(isPatientInquiryDetailExist);
                dbcontext.SaveChanges();

            }
        }

        public JQGridResponse<PatientInquiryViewModel> GetPatientInquiryList(JQGridSort jQGridSort)
        {
            IQueryable<PatientInquiryViewModel> list = GetPatientInquiryListQuery();
            var predicate = JQGridSorting.GeneratePredicate<PatientInquiryViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }

        public IQueryable<PatientInquiryViewModel> GetPatientInquiryListQuery()
        {
            var result = dbcontext.PatientInquiryDetailForms.Where(x => x.IsActive).Select(s => new PatientInquiryViewModel()
            {
                PatientId = s.PatientId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Age = s.Age.ToString(),
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                City = s.City,
                State = s.State,
                PostalCode = s.PostalCode.ToString(),
                Problem = s.Problem,
                Email = s.Email,
                Weight = s.Weight.ToString(),
                Height = s.Height.ToString(),
                Diabetes = s.Diabetes,
                Cancer = s.Cancer,
                Doyousmoke = s.Smoke,
                Doyoudrinkalchocol = s.Alchocol,
                ThyroidProblems = s.ThyroidProblems,
                HeartProblems = s.HeartProblems,
                LungProblems = s.LungProblems,
                BloodPressureProblems = s.BloodProblems,
                KidneyorLiverProblems = s.Kidney,              
                MedicalConditions = s.MedicalConditions,
                Allergy = s.Allergy,
                Lastdose = s.LastDose,
                IsActive = s.IsActive,



            }).ToList();
            result.ForEach(x => x.EncryptPatientId = Cryptography.EncryptStringToBytes_Aes(x.PatientId.ToString()));

            return result.AsQueryable();
        }
        public PatientInquiryViewModel GetPatientInquiryByPatientInquiryDetailId(int patientId)
        {
            var result = dbcontext.PatientInquiryDetailForms.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new PatientInquiryViewModel()
            {
                PatientId = s.PatientId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Age = s.Age.ToString(),
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                City = s.City,
                State = s.State,
                PostalCode = s.PostalCode.ToString(),
                Problem = s.Problem,
                Email = s.Email,
                Weight = s.Weight.ToString(),
                Height = s.Height.ToString(),
                Diabetes = s.Diabetes,
                Cancer = s.Cancer,
                Doyousmoke = s.Smoke,
                Doyoudrinkalchocol = s.Alchocol,
                ThyroidProblems = s.ThyroidProblems,
                HeartProblems = s.HeartProblems,
                LungProblems = s.LungProblems,
                BloodPressureProblems = s.BloodProblems,
                KidneyorLiverProblems = s.Kidney,
                MedicalConditions = s.MedicalConditions,
                Allergy = s.Allergy,
                Lastdose = s.LastDose,
                IsActive = s.IsActive,

            }).FirstOrDefault();

            return result;
        }
        //delete
        public void PatientInquiryDeletion(int patientId)
        {
            var patientInquirydetail = dbcontext.PatientInquiryDetailForms.Where(x => x.IsActive && x.PatientId == patientId).FirstOrDefault();
            if (patientInquirydetail != null)
            {
                patientInquirydetail.IsActive = false;
                dbcontext.Entry(patientInquirydetail);
                dbcontext.SaveChanges();
            }
        }
        public PatientInquiryViewModel GetPatientInquiryDetail(int patientId)
        {
            var result = dbcontext.PatientInquiryDetailForms.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new PatientInquiryViewModel()
            {
                PatientId = s.PatientId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                GuardianName = s.GuardianName,
                DateofBirth = s.DateofBirth,
                Age = s.Age.ToString(),
                PhoneNumber = s.PhoneNumber.ToString(),
                Address = s.Address,
                CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
                Country = s.Country,
                GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                Gender = s.Gender,
                City = s.City,
                State = s.State,
                PostalCode = s.PostalCode.ToString(),
                Problem = s.Problem,
                Email = s.Email,
                Weight = s.Weight.ToString(),
                Height = s.Height.ToString(),
                Diabetes = s.Diabetes,
                Cancer = s.Cancer,
                Doyousmoke = s.Smoke,
                Doyoudrinkalchocol = s.Alchocol,
                ThyroidProblems = s.ThyroidProblems,
                HeartProblems = s.HeartProblems,
                LungProblems = s.LungProblems,
                BloodPressureProblems = s.BloodProblems,
                KidneyorLiverProblems = s.Kidney,
                MedicalConditions = s.MedicalConditions,
                Allergy = s.Allergy,
                Lastdose = s.LastDose,
                AttachFileImage = s.MedicalDocuments,
                IsActive = s.IsActive,
            }).FirstOrDefault();
            return result;
        }
    }
}