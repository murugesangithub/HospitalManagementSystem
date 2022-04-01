using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class BillingRepository : BaseRepository
    {

        //insert
        public void BillingDetailInsertion(BillingViewModel billingViewModel)
        {
            BillingDetail billingDetail = new BillingDetail()
            {
                PatientId = billingViewModel.PatientId,
                PatientName = billingViewModel.PatientName,
                Department = billingViewModel.Department,
                DoctorName = billingViewModel.DoctorName,
                AdmitDate = billingViewModel.AdmitDate,
                DischargeDate = billingViewModel.DischargeDate,
                Service = billingViewModel.Service,
                CostofTreatment = (int)Convert.ToInt64(billingViewModel.CostofTreatment),
                Discount = (int)Convert.ToInt64(billingViewModel.Discount),
                TotalAmount = (int)Convert.ToInt64(billingViewModel.TotalAmount),
                Payment = billingViewModel.Payment,
                CheckNo = billingViewModel.CheckNo,
                PaymentStatus = billingViewModel.PaymentStatus,
                IsActive = true,
            };

            dbcontext.BillingDetails.Add(billingDetail);
            dbcontext.SaveChanges();
        }
        //update
        public void BillingDetailUpdation(BillingViewModel billingViewModel)
        {

            var isBillingDetailExist = dbcontext.BillingDetails.Where(x => x.IsActive && x.PatientId == billingViewModel.PatientId).FirstOrDefault();
            if (isBillingDetailExist != null)
            {

                isBillingDetailExist.PatientId = billingViewModel.PatientId;
                isBillingDetailExist.PatientName = billingViewModel.PatientName;
                isBillingDetailExist.Department = billingViewModel.Department;
                isBillingDetailExist.DoctorName = billingViewModel.DoctorName;
                isBillingDetailExist.AdmitDate = billingViewModel.AdmitDate;
                isBillingDetailExist.DischargeDate = billingViewModel.DischargeDate;
                isBillingDetailExist.Service = billingViewModel.Service;
                isBillingDetailExist.CostofTreatment = (int)Convert.ToInt64(billingViewModel.CostofTreatment);
                isBillingDetailExist.Discount = (int)Convert.ToInt64(billingViewModel.Discount);
                isBillingDetailExist.TotalAmount = (int)Convert.ToInt64(billingViewModel.TotalAmount);
                isBillingDetailExist.Payment = billingViewModel.Payment;
                isBillingDetailExist.CheckNo = billingViewModel.CheckNo;
                isBillingDetailExist.PaymentStatus = billingViewModel.PaymentStatus;

                isBillingDetailExist.IsActive = true;

                dbcontext.Entry(isBillingDetailExist);
                dbcontext.SaveChanges();

            }
        }

        //select

        public JQGridResponse<BillingViewModel> GetBillingList(JQGridSort jQGridSort)
        {
            IQueryable<BillingViewModel> list = GetBillingListQuery();
            var predicate = JQGridSorting.GeneratePredicate<BillingViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<BillingViewModel> GetBillingListQuery()
        {
            var result = dbcontext.BillingDetails.Where(x => x.IsActive).Select(s => new BillingViewModel()
            {
                PatientId = s.PatientId,
                PatientName = s.PatientName,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,
                DoctorName = s.DoctorName,
                AdmitDate = s.AdmitDate,
                DischargeDate = s.DischargeDate,
                ServiceDesc = dbcontext.Master_Service.Where(x => x.ServiceId == s.Service).Select(b => b.Description).FirstOrDefault(),
                Service = s.Service,
                CostofTreatment = s.CostofTreatment.ToString(),
                Discount = s.Discount.ToString(),
                TotalAmount = s.TotalAmount.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.Payment).Select(b => b.Method).FirstOrDefault(),
                Payment = s.Payment,
                CheckNo = s.CheckNo,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,

                IsActive = s.IsActive,

            }).ToList();
            result.ForEach(x => x.EncryptPatientId = Cryptography.EncryptStringToBytes_Aes(x.PatientId.ToString()));

            return result.AsQueryable();
        }

        public BillingViewModel GetBillingByBillingDetailId(int PatientId)
        {
            var result = dbcontext.BillingDetails.Where(x => x.IsActive && x.PatientId == PatientId).Select(s => new BillingViewModel()
            {

                PatientId = s.PatientId,
                PatientName = s.PatientName,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,
                DoctorName = s.DoctorName,
                AdmitDate = s.AdmitDate,
                DischargeDate = s.DischargeDate,
                ServiceDesc = dbcontext.Master_Service.Where(x => x.ServiceId == s.Service).Select(b => b.Description).FirstOrDefault(),
                Service = s.Service,
                CostofTreatment = s.CostofTreatment.ToString(),
                Discount = s.Discount.ToString(),
                TotalAmount = s.TotalAmount.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.Payment).Select(b => b.Method).FirstOrDefault(),
                Payment = s.Payment,
                CheckNo = s.CheckNo,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,

                IsActive = s.IsActive,

            }).FirstOrDefault();

            return result;
        }

        //delete
        public void BillingDeletion(int patientId)
        {
            var billingdetail = dbcontext.BillingDetails.Where(x => x.IsActive && x.PatientId == patientId).FirstOrDefault();
            if (billingdetail != null)
            {
                billingdetail.IsActive = false;
                dbcontext.Entry(billingdetail);
                dbcontext.SaveChanges();
            }


        }

        public BillingViewModel GetBillingDetail(int patientId)
        {
            var result = dbcontext.BillingDetails.Where(x => x.IsActive && x.PatientId == patientId).Select(s => new BillingViewModel()
            {

                PatientId = s.PatientId,
                PatientName = s.PatientName,
                DepartmentDesc = dbcontext.Master_Department.Where(x => x.DepartmentId == s.Department).Select(b => b.Description).FirstOrDefault(),
                Department = s.Department,
                DoctorName = s.DoctorName,
                AdmitDate = s.AdmitDate,
                DischargeDate = s.DischargeDate,
                ServiceDesc = dbcontext.Master_Service.Where(x => x.ServiceId == s.Service).Select(b => b.Description).FirstOrDefault(),
                Service = s.Service,
                CostofTreatment = s.CostofTreatment.ToString(),
                Discount = s.Discount.ToString(),
                TotalAmount = s.TotalAmount.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.Payment).Select(b => b.Method).FirstOrDefault(),
                Payment = s.Payment,
                CheckNo = s.CheckNo,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,

                IsActive = s.IsActive,

            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }


    }
}