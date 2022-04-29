
using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class PatientTreatmentRepository : BaseRepository
    {
        //insert
        public void PatientTreatmentDetailInsertion(PatientTreatmentViewModel patienttreatmentViewModel)
        {
            PatientTreatmentDetail patienttreatmentDetail = new PatientTreatmentDetail()
            {
                PatientId = patienttreatmentViewModel.PatientId,
                PatientName = patienttreatmentViewModel.PatientName,
                MedicineName = patienttreatmentViewModel.MedicineName,
                Quantity = (int)Convert.ToInt64(patienttreatmentViewModel.Quantity),
                DosageDesc = patienttreatmentViewModel.DosageDesc,
                Remarks = patienttreatmentViewModel.Remarks,
                RoomNumber = patienttreatmentViewModel.RoomNumber,
                RoomType = patienttreatmentViewModel.RoomType,
                NoofDays = patienttreatmentViewModel.Noofdays,
                RoomPrice = (int)Convert.ToInt64(patienttreatmentViewModel.RoomPrice),
                IsActive = true,
            };
            dbcontext.PatientTreatmentDetails.Add(patienttreatmentDetail);
            dbcontext.SaveChanges();
        }
        //update
        public void PatientTreatmentDetailUpdation(PatientTreatmentViewModel patienttreatmentViewModel)
        {
            var isPatienttreatmentDetailExist = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patienttreatmentViewModel.PatientId).FirstOrDefault();
            if (isPatienttreatmentDetailExist != null)
            {
                isPatienttreatmentDetailExist.PatientName= patienttreatmentViewModel.PatientName;
                isPatienttreatmentDetailExist.MedicineName = patienttreatmentViewModel.MedicineName;
                isPatienttreatmentDetailExist.Quantity = (int)Convert.ToInt64(patienttreatmentViewModel.Quantity);
                isPatienttreatmentDetailExist.DosageDesc = patienttreatmentViewModel.DosageDesc;
                isPatienttreatmentDetailExist.Remarks= patienttreatmentViewModel.Remarks;
                isPatienttreatmentDetailExist.RoomNumber = patienttreatmentViewModel.RoomNumber;
                isPatienttreatmentDetailExist.RoomType = patienttreatmentViewModel.RoomType;
                isPatienttreatmentDetailExist.NoofDays= patienttreatmentViewModel.Noofdays;
                isPatienttreatmentDetailExist.RoomPrice = (int)Convert.ToInt64(patienttreatmentViewModel.RoomPrice);
               

                isPatienttreatmentDetailExist.IsActive = true;
                dbcontext.Entry(isPatienttreatmentDetailExist);
                dbcontext.SaveChanges();
            }

        }

        public JQGridResponse<PatientTreatmentViewModel> GetPatientTreatmentList(JQGridSort jQGridSort)
        {
            IQueryable<PatientTreatmentViewModel> list = GetPatientTreatmentListQuery();
            var predicate = JQGridSorting.GeneratePredicate<PatientTreatmentViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<PatientTreatmentViewModel> GetPatientTreatmentListQuery()
        {
            var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive).Select(s => new PatientTreatmentViewModel()
            {
                PatientId = s.PatientId,
                PatientName = s.PatientName,
                MedicineNameDescription = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.MedicineName).Select(b => b.Description).FirstOrDefault(),
                MedicineName = s.MedicineName,
                Quantity = s.Quantity.ToString(),
                DosageDesc = s.DosageDesc,
                Remarks = s.Remarks,
                RoomNumberDescription = dbcontext.Master_RoomNumber.Where(x => x.RoomNumberId == s.RoomNumber).Select(b => b.Description).FirstOrDefault(),
                RoomNumber = s.RoomNumber,
                RoomTypeDescription = dbcontext.Master_RoomType.Where(x => x.RoomTypeId == s.RoomType).Select(b => b.Description).FirstOrDefault(),
                RoomType = s.RoomType,
                Noofdays = s.NoofDays,
                RoomPrice = s.RoomPrice.ToString(),
                IsActive = s.IsActive,

            }).ToList();
            result.ForEach(x => x.EncryptPatientId = Cryptography.EncryptStringToBytes_Aes(x.PatientId.ToString()));

            return result.AsQueryable();
        }

        public PatientTreatmentViewModel GetPatientTreatmentByPatientTreamentId(int PatientId)
        {
            var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive).Select(s => new PatientTreatmentViewModel()
            {
                PatientId = s.PatientId,
                PatientName = s.PatientName,
                MedicineNameDescription = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.MedicineName).Select(b => b.Description).FirstOrDefault(),
                MedicineName = s.MedicineName,
                Quantity = s.Quantity.ToString(),
                DosageDesc = s.DosageDesc,
                Remarks = s.Remarks,
                RoomNumberDescription = dbcontext.Master_RoomNumber.Where(x => x.RoomNumberId == s.RoomNumber).Select(b => b.Description).FirstOrDefault(),
                RoomNumber = s.RoomNumber,
                RoomTypeDescription = dbcontext.Master_RoomType.Where(x => x.RoomTypeId == s.RoomType).Select(b => b.Description).FirstOrDefault(),
                RoomType = s.RoomType,
                Noofdays = s.NoofDays,
                RoomPrice = s.RoomPrice.ToString(),
                IsActive = s.IsActive,
            }).FirstOrDefault();
            return result;
        }

        public void PatientTreatmentDeletion(int patientId)
        {
            var patienttreatmentdetail = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientId).FirstOrDefault();
            if (patienttreatmentdetail != null)
            {
                patienttreatmentdetail.IsActive = false;
                dbcontext.Entry(patienttreatmentdetail);

                dbcontext.SaveChanges();
            }
        }
        //icon
        public PatientTreatmentViewModel GetPatientTreatmentDetail(int patientId)
        {
            var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new PatientTreatmentViewModel()
            {
                PatientId = s.PatientId,

                PatientName = s.PatientName,
                MedicineNameDescription = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.MedicineName).Select(b => b.Description).FirstOrDefault(),
                MedicineName = s.MedicineName,
                Quantity = s.Quantity.ToString(),
                DosageDesc = s.DosageDesc,
                Remarks = s.Remarks,
                RoomNumberDescription = dbcontext.Master_RoomNumber.Where(x => x.RoomNumberId == s.RoomNumber).Select(b => b.Description).FirstOrDefault(),
                RoomNumber = s.RoomNumber,
                RoomTypeDescription = dbcontext.Master_RoomType.Where(x => x.RoomTypeId == s.RoomType).Select(b => b.Description).FirstOrDefault(),
                RoomType = s.RoomType,
                Noofdays = s.NoofDays,
                RoomPrice = s.RoomPrice.ToString(),
                IsActive = s.IsActive,
            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }

    }
}