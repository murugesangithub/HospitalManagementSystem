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
        //public void PatientInquiryDetailInsertion(PatientInquiryViewModel patientinquiryViewModel)
        //{
        //    PatientInquiryFormDetail patientInquiryFormDetail = new PatientInquiryFormDetail()
        //    {
        //        PatientInquiryId = patientinquiryViewModel.PatientInquiryId,
        //        FirstName = patientinquiryViewModel.FirstName,
        //        LastName = patientinquiryViewModel.LastName,
        //        GuardianName = patientinquiryViewModel.GuardianName,
        //        DateofBirth = patientinquiryViewModel.DateofBirth,
        //        Age = Convert.ToInt32(patientinquiryViewModel.Age),
        //        PhoneNumber = (int)Convert.ToInt64(patientinquiryViewModel.PhoneNumber),
        //        Address = patientinquiryViewModel.Address,
        //        Country = patientinquiryViewModel.Country,
        //        Gender = patientinquiryViewModel.Gender,
        //        City = patientinquiryViewModel.City,
        //        State = patientinquiryViewModel.State,
        //        PostalCode = patientinquiryViewModel.PostalCode,
        //        Problem = patientinquiryViewModel.Problem,
        //        Email = patientinquiryViewModel.Email,
        //        Height = patientinquiryViewModel.Height,
        //        weight = patientinquiryViewModel.Weight,
        //        Diabetes = patientinquiryViewModel.Diabetes,
        //        Cancer = patientinquiryViewModel.Cancer,
        //       Doyousmoke= patientinquiryViewModel.Doyousmoke,
        //       Doyoudrinkalchocol= patientinquiryViewModel.Doyoudrinkalchocol,
        //        ThyroidProblems = patientinquiryViewModel.ThyroidProblems,
        //        HeartProblems = patientinquiryViewModel.HeartProblems,
        //        LungProblems = patientinquiryViewModel.LungProblems,
        //        BloodPressureProblems = patientinquiryViewModel.BloodPressureProblems,
        //      KidneyorLiverProblems = patientinquiryViewModel.KidneyorLiverProblems,
        //      MedicalConditions = patientinquiryViewModel.MedicalConditions,
        //        Allergy = patientinquiryViewModel.Allergy,
        //        Lastdose = patientinquiryViewModel.Lastdose,

        //        IsActive = true,
        //    };
        //    dbcontext.PatientInquiryFormDetails.Add(patientInquiryFormDetail);
        //    dbcontext.SaveChanges();
        //}
        //public void PatientInquiryDetailUpdation(PatientInquiryViewModel patientinquiryViewModel)
        //{
        //    var isPatientInquiryDetailExist = dbcontext.PatientInquiryFormDetails.Where(x => x.IsActive && x.PatientInquiryId == patientinquiryViewModel.PatientInquiryId).FirstOrDefault();
        //    if (isPatientInquiryDetailExist != null)
        //    {
        //        isPatientInquiryDetailExist.PatientInquiryId = patientinquiryViewModel.PatientInquiryId;
        //        isPatientInquiryDetailExist.FirstName = patientinquiryViewModel.FirstName;
        //        isPatientInquiryDetailExist.LastName = patientinquiryViewModel.LastName;
        //        isPatientInquiryDetailExist.Email = patientinquiryViewModel.Email;
        //        isPatientInquiryDetailExist.Address = patientinquiryViewModel.Address;
        //        isPatientInquiryDetailExist.Age = Convert.ToInt32(patientinquiryViewModel.Age);
        //        isPatientInquiryDetailExist.PhoneNumber = (int)Convert.ToInt64(patientinquiryViewModel.PhoneNumber);
        //        isPatientInquiryDetailExist.GuardianName = patientinquiryViewModel.GuardianName;
        //        isPatientInquiryDetailExist.Country = patientinquiryViewModel.Country;
        //        isPatientInquiryDetailExist.Gender = patientinquiryViewModel.Gender;
        //        isPatientInquiryDetailExist.City = patientinquiryViewModel.City;
        //        isPatientInquiryDetailExist.State = patientinquiryViewModel.State;
        //        isPatientInquiryDetailExist.PostalCode = patientinquiryViewModel.PostalCode;
        //        isPatientInquiryDetailExist.Problem = patientinquiryViewModel.Problem;
        //        isPatientInquiryDetailExist.Height = patientinquiryViewModel.Height;
        //        isPatientInquiryDetailExist.Diabetes = patientinquiryViewModel.Diabetes;
        //        isPatientInquiryDetailExist.Cancer = patientinquiryViewModel.Cancer;
        //        isPatientInquiryDetailExist.Doyoudrinkalchocol = patientinquiryViewModel.Doyoudrinkalchocol;
        //        isPatientInquiryDetailExist.ThyroidProblems = patientinquiryViewModel.ThyroidProblems;
        //        isPatientInquiryDetailExist.HeartProblems = patientinquiryViewModel.HeartProblems;
        //        isPatientInquiryDetailExist.LungProblems = patientinquiryViewModel.LungProblems;
        //        isPatientInquiryDetailExist.BloodPressureProblems = patientinquiryViewModel.BloodPressureProblems;
        //        isPatientInquiryDetailExist.KidneyorLiverProblems = patientinquiryViewModel.KidneyorLiverProblems;
        //        isPatientInquiryDetailExist.weight = patientinquiryViewModel.Weight;
        //        isPatientInquiryDetailExist.MedicalConditions = patientinquiryViewModel.MedicalConditions;
        //        isPatientInquiryDetailExist.Allergy = patientinquiryViewModel.Allergy;
        //        isPatientInquiryDetailExist.Lastdose = patientinquiryViewModel.Lastdose;
        //        isPatientInquiryDetailExist.IsActive = true;

        //        dbcontext.Entry(isPatientInquiryDetailExist);
        //        dbcontext.SaveChanges();

        //    }
        //}

        //public JQGridResponse<PatientInquiryViewModel> GetPatientInquiryList(JQGridSort jQGridSort)
        //{
        //    IQueryable<PatientInquiryViewModel> list = GetPatientInquiryListQuery();
        //    var predicate = JQGridSorting.GeneratePredicate<PatientInquiryViewModel>(jQGridSort);
        //    var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
        //    return result;
        //}

        //public IQueryable<PatientInquiryViewModel> GetPatientInquiryListQuery()
        //{
        //    var result = dbcontext.PatientInquiryFormDetails.Where(x => x.IsActive).Select(s => new PatientInquiryViewModel()
        //    {
        //        PatientInquiryId = s.PatientInquiryId,
        //        FirstName = s.FirstName,
        //        LastName = s.LastName,
        //        GuardianName = s.GuardianName,
        //        DateofBirth = s.DateofBirth,
        //        Age = s.Age.ToString(),
        //        PhoneNumber = s.PhoneNumber.ToString(),
        //        Address = s.Address,
        //        CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
        //        Country = s.Country,
        //        GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
        //        Gender = s.Gender,
        //        City = s.City,
        //        State = s.State,
        //        PostalCode = s.PostalCode,
        //        Problem = s.Problem,
        //        Email = s.Email,
        //        Height = s.Height,
        //        Diabetes = s.Diabetes,
        //        Cancer = s.Cancer,
        //        Doyousmoke = s.Doyousmoke,
        //        Doyoudrinkalchocol = s.Doyoudrinkalchocol,
        //        ThyroidProblems = s.ThyroidProblems,
        //        HeartProblems = s.HeartProblems,
        //        LungProblems = s.LungProblems,
        //        BloodPressureProblems = s.BloodPressureProblems,
        //        KidneyorLiverProblems = s.KidneyorLiverProblems,
        //        Weight = s.weight,
        //        MedicalConditions = s.MedicalConditions,
        //        Allergy = s.Allergy,
        //        Lastdose = s.Lastdose,
        //        IsActive = s.IsActive,



        //    }).ToList();
        //    result.ForEach(x => x.EncryptPatientInquiryId = Cryptography.EncryptStringToBytes_Aes(x.PatientInquiryId.ToString()));

        //    return result.AsQueryable();
        //}
        //public PatientInquiryViewModel GetPatientInquiryByPatientInquiryDetailId(int patientId)
        //{
        //    var result = dbcontext.PatientInquiryFormDetails.Where(x => x.IsActive && x.PatientInquiryId == patientId).Select(s => new PatientInquiryViewModel()
        //    {

        //        PatientInquiryId = s.PatientInquiryId,
        //        FirstName = s.FirstName,
        //        LastName = s.LastName,
        //        GuardianName = s.GuardianName,
        //        DateofBirth = s.DateofBirth,
        //        Age = s.Age.ToString(),
        //        PhoneNumber = s.PhoneNumber.ToString(),
        //        Address = s.Address,
        //        CountryDesc = dbcontext.Master_Country.Where(x => x.CountryId == s.Country).Select(b => b.Description).FirstOrDefault(),
        //        Country = s.Country,
        //        GenderDescription = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
        //        Gender = s.Gender,
        //        City = s.City,
        //        State = s.State,
        //        PostalCode = s.PostalCode,
        //        Problem = s.Problem,
        //        Email = s.Email,
        //        Height = s.Height,
        //        Diabetes = s.Diabetes,
        //        Cancer = s.Cancer,
        //        Doyousmoke = s.Doyousmoke,
        //        Doyoudrinkalchocol = s.Doyoudrinkalchocol,
        //        ThyroidProblems = s.ThyroidProblems,
        //        HeartProblems = s.HeartProblems,
        //        LungProblems = s.LungProblems,
        //        BloodPressureProblems = s.BloodPressureProblems,
        //        KidneyorLiverProblems = s.KidneyorLiverProblems,
        //        Weight = s.weight,
        //        MedicalConditions = s.MedicalConditions,
        //        Allergy = s.Allergy,
        //        Lastdose = s.Lastdose,
        //        IsActive = s.IsActive,
        //    }).FirstOrDefault();

        //    return result;
        //}
        ////delete
    }
}