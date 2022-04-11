using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class DoctorRepository : BaseRepository
    {
        public void DoctorDetailInsertion(DoctorViewModel doctorViewModel)
        {
            DoctorDetail doctorDetail = new DoctorDetail()
            {
                FirstName = doctorViewModel.FirstName,
                LastName = doctorViewModel.LastName,
                Email = doctorViewModel.Email,
                MobileNo = doctorViewModel.MobileNo,
                Address = doctorViewModel.Address,
                Gender = doctorViewModel.Gender,
                City = doctorViewModel.City,
                State = doctorViewModel.State,
                Specialist = doctorViewModel.Specialist,
                IsActive = true,
            };
            dbcontext.DoctorDetails.Add(doctorDetail);
            dbcontext.SaveChanges();
        }
        public JQGridResponse<DoctorViewModel> GetDoctorList(JQGridSort jQGridSort)
        {
            IQueryable<DoctorViewModel> list = GetDoctorListQuery();
            var predicate = JQGridSorting.GeneratePredicate<DoctorViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<DoctorViewModel> GetDoctorListQuery()
        {
            var result = dbcontext.DoctorDetails.Where(x => x.IsActive).Select(s => new DoctorViewModel()
            {
                DoctorDetailId = s.DoctorDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                MobileNo = s.MobileNo,
                Address = s.Address,
                Gender = s.Gender,
                GenderDesc = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                State = s.State,
                StateDesc = dbcontext.Master_State.Where(x => x.StateId == s.State).Select(b => b.Description).FirstOrDefault(),
                City = s.City,
                CityDesc = dbcontext.Master_City.Where(x => x.CityId == s.City).Select(b => b.Description).FirstOrDefault(),
                Specialist = s.Specialist,
                SpecialistDesc = dbcontext.Master_Specialist.Where(x => x.SpecialistId == s.Specialist).Select(b => b.Description).FirstOrDefault(),
                IsActive = s.IsActive,
            }).ToList();
            result.ForEach(x => x.EncryptDoctorDetailId = Cryptography.EncryptStringToBytes_Aes(x.DoctorDetailId.ToString()));
            return result.AsQueryable();
        }
        public DoctorViewModel GetDoctorDetailById(int doctorDetailId)
        {
            var result = dbcontext.DoctorDetails.Where(x => x.IsActive && x.DoctorDetailId == doctorDetailId).Select(s => new DoctorViewModel()
            {
                DoctorDetailId = s.DoctorDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                MobileNo = s.MobileNo,
                Address = s.Address,
                Gender = s.Gender,
                GenderDesc = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                State = s.State,
                StateDesc = dbcontext.Master_State.Where(x => x.StateId == s.State).Select(b => b.Description).FirstOrDefault(),
                City = s.City,
                CityDesc = dbcontext.Master_City.Where(x => x.CityId == s.City).Select(b => b.Description).FirstOrDefault(),
                Specialist = s.Specialist,
                SpecialistDesc = dbcontext.Master_Specialist.Where(x => x.SpecialistId == s.Specialist).Select(b => b.Description).FirstOrDefault(),
                IsActive = s.IsActive,
            }).FirstOrDefault();
            return result;
        }
        public void doctorDeletion(int doctorDetailId)
        {
            var doctordetail = dbcontext.DoctorDetails.Where(x => x.IsActive && x.DoctorDetailId == doctorDetailId).FirstOrDefault();
            if (doctordetail != null)
            {
                doctordetail.IsActive = false;
                dbcontext.Entry(doctordetail);
                dbcontext.SaveChanges();
            }
        }
        //update
        public void DoctorDetailUpdation(DoctorViewModel doctorViewModel)
        {
            var isDoctorDetailExit = dbcontext.DoctorDetails.Where(x => x.IsActive && x.DoctorDetailId == doctorViewModel.DoctorDetailId).FirstOrDefault();
            if (isDoctorDetailExit != null)
            {
                isDoctorDetailExit.FirstName = doctorViewModel.FirstName;
                isDoctorDetailExit.LastName = doctorViewModel.LastName;
                isDoctorDetailExit.MobileNo = doctorViewModel.MobileNo;
                isDoctorDetailExit.Address = doctorViewModel.Address;
                isDoctorDetailExit.Gender = doctorViewModel.Gender;
                isDoctorDetailExit.City = doctorViewModel.City;
                isDoctorDetailExit.State = doctorViewModel.State;
                isDoctorDetailExit.Specialist = doctorViewModel.Specialist;
                isDoctorDetailExit.IsActive = true;
                dbcontext.Entry(isDoctorDetailExit);
                dbcontext.SaveChanges();
            }
        }
        //icon
        public DoctorViewModel GetDoctorDetail(int doctorDetailId)
        {
            var result = dbcontext.DoctorDetails.Where(x => x.IsActive && x.DoctorDetailId == doctorDetailId).Select(s => new DoctorViewModel()
            {
                DoctorDetailId = s.DoctorDetailId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                MobileNo = s.MobileNo,
                Address = s.Address,
                Gender = s.Gender,
                GenderDesc = dbcontext.Master_Gender.Where(x => x.GenderId == s.Gender).Select(b => b.Description).FirstOrDefault(),
                State = s.State,
                StateDesc = dbcontext.Master_State.Where(x => x.StateId == s.State).Select(b => b.Description).FirstOrDefault(),
                City = s.City,
                CityDesc = dbcontext.Master_City.Where(x => x.CityId == s.City).Select(b => b.Description).FirstOrDefault(),
                Specialist = s.Specialist,
                SpecialistDesc = dbcontext.Master_Specialist.Where(x => x.SpecialistId == s.Specialist).Select(b => b.Description).FirstOrDefault(),
                IsActive = s.IsActive,
            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }
    }
}