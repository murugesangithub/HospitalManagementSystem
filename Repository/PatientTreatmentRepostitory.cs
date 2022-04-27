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
        //public void PatientTreatmentDetailInsertion(PatientTreatmentViewModel patientTreatmentViewModel)
        //{
        //   PatientTreatmentDetail patientTreatmentDetail = new PatientTreatmentDetail()
        //    {
        //        PatientId = patientTreatmentViewModel.PatientId,
        //        PatientName = patientTreatmentViewModel.PatientName,
        //        //MedicineName= patientTreatmentViewModel.MedicineName,
        //        Quantity = Convert.ToInt32(patientTreatmentViewModel.Quantity),
        //       DosageDesc = patientTreatmentViewModel.DosageDesc,
        //        Remarks = patientTreatmentViewModel.Remarks,
        //        RoomNumber = Convert.ToInt32(patientTreatmentViewModel.RoomNumber),
        //       RoomType = patientTreatmentViewModel.RoomType,
        //       RoomPrice= Convert.ToInt32(patientTreatmentViewModel.RoomPrice),
        //        IsActive = true,
        //    };
        //    dbcontext.PatientTreatmentDetails.Add(patientTreatmentDetail);
        //    dbcontext.SaveChanges();
        //}
        ////update
        //public void PatientTreatmentDetailUpdation(PatientTreatmentViewModel patientTreatmentViewModel)
        //{
        //    var isPatientTreatmentDetailExist = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientTreatmentViewModel.PatientId).FirstOrDefault();
        //    if (isPatientTreatmentDetailExist != null)
        //    {
        //        isPatientTreatmentDetailExist.PatientId = patientTreatmentViewModel.PatientId;
        //        isPatientTreatmentDetailExist.PatientName = patientTreatmentViewModel.PatientName;
        //        //isPatientTreatmentDetailExist.MedicineName = patientTreatmentViewModel.MedicineName;
        //        isPatientTreatmentDetailExist.Quantity = Convert.ToInt32(patientTreatmentViewModel.Quantity);
        //        isPatientTreatmentDetailExist.DosageDesc = patientTreatmentViewModel.DosageDesc;
        //        isPatientTreatmentDetailExist.Remarks =patientTreatmentViewModel.Remarks;
        //        isPatientTreatmentDetailExist.RoomNumber = Convert.ToInt32(patientTreatmentViewModel.RoomNumber);
        //        isPatientTreatmentDetailExist.RoomType = patientTreatmentViewModel.RoomType;
        //        isPatientTreatmentDetailExist.RoomPrice = Convert.ToInt32(patientTreatmentViewModel.RoomPrice);  
        //        isPatientTreatmentDetailExist.IsActive = true;
        //        dbcontext.Entry(isPatientTreatmentDetailExist);
        //        dbcontext.SaveChanges();
        //    }
        //}
        ////select
        //public JQGridResponse<PatientTreatmentViewModel> GetPatientTreatmentList(JQGridSort jQGridSort)
        //{
        //    IQueryable<PatientTreatmentViewModel> list = GetPatientTreatmentListQuery();
        //    var predicate = JQGridSorting.GeneratePredicate<PatientTreatmentViewModel>(jQGridSort);
        //    var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
        //    return result;
        //}
        //public IQueryable<PatientTreatmentViewModel> GetPatientTreatmentListQuery()
        //{
        //    var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive).Select(s => new PatientTreatmentViewModel()
        //    {
        //        PatientId = s.PatientId,
        //        PatientName = s.PatientName,
        //        //MedicineName = s.MedicineName,
        //        Quantity = s.Quantity.ToString(),         
        //       DosageDesc = s.DosageDesc,
        //       Remarks= s.Remarks,
        //       RoomNumber = s.RoomNumber.ToString(),
        //       RoomType = s.RoomType,
        //        RoomPrice = s.RoomPrice.ToString(),             
        //        IsActive = s.IsActive,

        //    }).ToList();
        //    result.ForEach(x => x.EncryptPatientId = Cryptography.EncryptStringToBytes_Aes(x.PatientId.ToString()));
        //    return result.AsQueryable();
        //}
        //public PatientTreatmentViewModel GetPatientTreatmentByPatientTreatmentDetailId(int patientId)
        //{
        //    var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new PatientTreatmentViewModel()
        //    {
        //        PatientId = s.PatientId,
        //        PatientName = s.PatientName,
        //        //MedicineName = s.MedicineName,
        //        Quantity = s.Quantity.ToString(),
        //        DosageDesc = s.DosageDesc,
        //        Remarks = s.Remarks,
        //        RoomNumber = s.RoomNumber.ToString(),
        //        RoomType = s.RoomType,
        //        RoomPrice = s.RoomPrice.ToString(),
        //        IsActive = s.IsActive,

        //    }).FirstOrDefault();

        //    return result;
        //}
        ////delete
        //public void PatientTreatmentDeletion(int patientId)
        //{
        //    var patientTreatmentdetail = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientId).FirstOrDefault();
        //    if (patientTreatmentdetail != null)
        //    {
        //        patientTreatmentdetail.IsActive = false;
        //        dbcontext.Entry(patientTreatmentdetail);
        //        dbcontext.SaveChanges();
        //    }
        //}
        ////icon
        //public PatientTreatmentViewModel GetPatientTreatmentDetail(int patientId)
        //{
        //    var result = dbcontext.PatientTreatmentDetails.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new PatientTreatmentViewModel()
        //    {
        //        PatientId = s.PatientId,
        //        PatientName = s.PatientName,
        //        //MedicineName = s.MedicineName,
        //        Quantity = s.Quantity.ToString(),
        //        DosageDesc = s.DosageDesc,
        //        Remarks = s.Remarks,
        //        RoomNumber = s.RoomNumber.ToString(),
        //        RoomType = s.RoomType,
        //        RoomPrice = s.RoomPrice.ToString(),
        //        IsActive = s.IsActive,
        //    }).FirstOrDefault();
        //    //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
        //    return result;
        //}
    }
}