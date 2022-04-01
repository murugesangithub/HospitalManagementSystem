
using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class PurchaseMedicineRepository : BaseRepository
    {
        public void PurchaseMedicineDetailInsertion(PurchaseMedicineViewModel purchaseMedicineViewModel)
        {

            PurchaseMedicineDetail purchaseMedicineDetail = new PurchaseMedicineDetail()
            {
                MedicineId = purchaseMedicineViewModel.MedicineId,
               SupplierName = purchaseMedicineViewModel.SupplierName,
                 Code= purchaseMedicineViewModel.Code,
                Date= purchaseMedicineViewModel.Date,
               Category = purchaseMedicineViewModel.Category,
              Medicine= purchaseMedicineViewModel.Medicine,
             Quantity= Convert.ToInt32(purchaseMedicineViewModel.Quantity),
              Notes = purchaseMedicineViewModel.Notes,
                Discount = Convert.ToInt32(purchaseMedicineViewModel.Discount),
               GrandTotal = Convert.ToInt32(purchaseMedicineViewModel.GrandTotal),
                PaymentType= purchaseMedicineViewModel.Payment,
                PaymentStatus= purchaseMedicineViewModel.PaymentStatus,

                IsActive = true,
            };

            dbcontext.PurchaseMedicineDetails.Add(purchaseMedicineDetail);
            dbcontext.SaveChanges();



        }
        //update
        public void PurchaseDetailUpdation(PurchaseMedicineViewModel purchaseMedicineViewModel)
        {

            var isPurchaseMedicineDetailExist = dbcontext.PurchaseMedicineDetails.Where(x => x.IsActive && x.MedicineId == purchaseMedicineViewModel.MedicineId).FirstOrDefault();
            if (isPurchaseMedicineDetailExist != null)
            {

                isPurchaseMedicineDetailExist.MedicineId = purchaseMedicineViewModel.MedicineId;
                isPurchaseMedicineDetailExist.SupplierName = purchaseMedicineViewModel.SupplierName;
                isPurchaseMedicineDetailExist.Code = purchaseMedicineViewModel.Code;
                isPurchaseMedicineDetailExist.Date = purchaseMedicineViewModel.Date;
                isPurchaseMedicineDetailExist.Category = purchaseMedicineViewModel.Category;
                isPurchaseMedicineDetailExist.Medicine = purchaseMedicineViewModel.Medicine;
                isPurchaseMedicineDetailExist.Quantity = Convert.ToInt32(purchaseMedicineViewModel.Quantity);
                isPurchaseMedicineDetailExist.Notes = purchaseMedicineViewModel.Notes;
                isPurchaseMedicineDetailExist.Discount = Convert.ToInt32(purchaseMedicineViewModel.Discount);
                isPurchaseMedicineDetailExist.GrandTotal = Convert.ToInt32(purchaseMedicineViewModel.GrandTotal);
                isPurchaseMedicineDetailExist.PaymentType = purchaseMedicineViewModel.Payment;
                isPurchaseMedicineDetailExist.PaymentStatus = purchaseMedicineViewModel.PaymentStatus;
          

                isPurchaseMedicineDetailExist.IsActive = true;

                dbcontext.Entry(isPurchaseMedicineDetailExist);
                dbcontext.SaveChanges();

            }
        }

        //select

        public JQGridResponse<PurchaseMedicineViewModel> GetPurchaseMedicineList(JQGridSort jQGridSort)
        {
            IQueryable<PurchaseMedicineViewModel> list = GetPurchaseMedicineListQuery();
            var predicate = JQGridSorting.GeneratePredicate<PurchaseMedicineViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<PurchaseMedicineViewModel> GetPurchaseMedicineListQuery()
        {
            var result = dbcontext.PurchaseMedicineDetails.Where(x => x.IsActive).Select(s => new PurchaseMedicineViewModel()
            {
               MedicineId= s.MedicineId,
                SupplierName = s.SupplierName,
                Code = s.Code,
                Date = s.Date,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
               Category= s.Category,
                MedicineDesc = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.Medicine).Select(b => b.Description).FirstOrDefault(),
               Medicine = s.Medicine,
                Quantity = s.Quantity.ToString(),
                Notes=s.Notes,
                Discount = s.Discount.ToString(),
                GrandTotal = s.GrandTotal.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.PaymentType).Select(b => b.Method).FirstOrDefault(),
                Payment = s.PaymentType,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,
                IsActive = s.IsActive,

            }).ToList();
            result.ForEach(x => x.EncryptMedicineId = Cryptography.EncryptStringToBytes_Aes(x.MedicineId.ToString()));

            return result.AsQueryable();
        }

        public PurchaseMedicineViewModel GetPurchaseMedicineByPurchaseMedicineDetailId(int medicineId)
        {
            var result = dbcontext.PurchaseMedicineDetails.Where(x => x.IsActive && x.MedicineId == medicineId).Select(s => new PurchaseMedicineViewModel()
            {
                MedicineId = s.MedicineId,
                SupplierName = s.SupplierName,
                Code = s.Code,
                Date = s.Date,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                MedicineDesc = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.Medicine).Select(b => b.Description).FirstOrDefault(),
                Medicine = s.Medicine,
                Quantity = s.Quantity.ToString(),
                Notes = s.Notes,
                Discount = s.Discount.ToString(),
                GrandTotal = s.GrandTotal.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.PaymentType).Select(b => b.Method).FirstOrDefault(),
                Payment = s.PaymentType,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,
                IsActive = s.IsActive,

                

            }).FirstOrDefault();

            return result;
        }

        //delete
        public void PurchaseMedicineDeletion(int medicineId)
        {
            var purchaseMedicineDetail = dbcontext.PurchaseMedicineDetails.Where(x => x.IsActive && x.MedicineId == medicineId).FirstOrDefault();
            if (purchaseMedicineDetail != null)
            {
                purchaseMedicineDetail.IsActive = false;
                dbcontext.Entry(purchaseMedicineDetail);
                dbcontext.SaveChanges();
            }


        }


        //icon

        public PurchaseMedicineViewModel GetPurchaseMedicineDetail(int MedicineId)
        {
            var result = dbcontext.PurchaseMedicineDetails.Where(x => x.IsActive && x.MedicineId == MedicineId).Select(s => new PurchaseMedicineViewModel()
            {

                MedicineId = s.MedicineId,
                SupplierName = s.SupplierName,
                Code = s.Code,
                Date = s.Date,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                MedicineDesc = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.Medicine).Select(b => b.Description).FirstOrDefault(),
                Medicine = s.Medicine,
                Quantity = s.Quantity.ToString(),
                Notes = s.Notes,
                Discount = s.Discount.ToString(),
                GrandTotal = s.GrandTotal.ToString(),
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.PaymentType).Select(b => b.Method).FirstOrDefault(),
                Payment = s.PaymentType,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.PaymentStatus).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.PaymentStatus,
                IsActive = s.IsActive,
            }).FirstOrDefault();
            //result.ForEach(x => x.EncryptUserDetailId = Cryptography.EncryptStringToBytes_Aes(x.UserDetailId.ToString()));
            return result;
        }

    }
}