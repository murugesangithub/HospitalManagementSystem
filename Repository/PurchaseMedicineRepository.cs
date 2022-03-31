
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
        public void PurchaseDetailInsertion(PurchaseMedicineViewModel purchaseMedicineViewModel)
        {
            //insert

            PurchaseDetail purchaseDetail = new PurchaseDetail()
            {
                PurchaseMedicineId = purchaseMedicineViewModel.PurchaseMedicineId,
                SupplierName = purchaseMedicineViewModel.SupplierName,
                Code = purchaseMedicineViewModel.Code,
                Date = purchaseMedicineViewModel.Date,
                Category = purchaseMedicineViewModel.Category,
                Medicine = purchaseMedicineViewModel.Medicine,
                Quantity = purchaseMedicineViewModel.Quantity,
                Notes = purchaseMedicineViewModel.Notes,
                Discount = purchaseMedicineViewModel.Discount,
                GrandTotal = purchaseMedicineViewModel.GrandTotal,
                Payment = purchaseMedicineViewModel.Payment,
              Status = purchaseMedicineViewModel.PaymentStatus,
                IsActive = true,
            };

            dbcontext.PurchaseDetails.Add(purchaseDetail);
            dbcontext.SaveChanges();



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
            var result = dbcontext.PurchaseDetails.Where(x => x.IsActive).Select(s => new PurchaseMedicineViewModel()
            {
                PurchaseMedicineId = s.PurchaseMedicineId,
                SupplierName = s.SupplierName,
                Code = s.Code,
                Date = s.Date,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                MedicineDesc = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.Medicine).Select(b => b.Description).FirstOrDefault(),
                Medicine = s.Medicine,
                Quantity = s.Quantity,
                Notes = s.Notes,
                Discount = s.Discount,
                GrandTotal = s.GrandTotal,
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.Payment).Select(b => b.Method).FirstOrDefault(),
                Payment = s.Payment,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.Status).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.Status,

                IsActive = s.IsActive,

            }).ToList();  
            result.ForEach(x => x.EncryptPurchaseMedicineId = Cryptography.EncryptStringToBytes_Aes(x.PurchaseMedicineId.ToString()));
            return result.AsQueryable();
        }





        //delete



        public void PurchaseMedicineDeletion(int purchaseMedicineId)
        {
            var PurchaseDetail = dbcontext.PurchaseDetails.Where(x => x.IsActive && x.PurchaseMedicineId == purchaseMedicineId).FirstOrDefault();

            {
                PurchaseDetail.IsActive = false;
                dbcontext.Entry(PurchaseDetail);
                dbcontext.SaveChanges();
            }


        }





        //update


        public void PurcaseMedicineUpdation(PurchaseMedicineViewModel purcaseMedicineViewModel)
        {
            var isPurchaseDetailExist = dbcontext.PurchaseDetails.Where(x => x.IsActive && x.PurchaseMedicineId == purcaseMedicineViewModel.PurchaseMedicineId).FirstOrDefault();
            if (isPurchaseDetailExist != null)
            {



                isPurchaseDetailExist.SupplierName = purcaseMedicineViewModel.SupplierName;
                isPurchaseDetailExist.Code = purcaseMedicineViewModel.Code;
                isPurchaseDetailExist.Date = purcaseMedicineViewModel.Date;
                isPurchaseDetailExist.Category = purcaseMedicineViewModel.Category;
                isPurchaseDetailExist.Medicine = purcaseMedicineViewModel.Medicine;
                isPurchaseDetailExist.Quantity = purcaseMedicineViewModel.Quantity;
                isPurchaseDetailExist.Notes = purcaseMedicineViewModel.Notes;
                isPurchaseDetailExist.Discount = purcaseMedicineViewModel.Discount;
                isPurchaseDetailExist.GrandTotal = purcaseMedicineViewModel.GrandTotal;
                isPurchaseDetailExist.Payment = purcaseMedicineViewModel.Payment;
                isPurchaseDetailExist.Status = purcaseMedicineViewModel.PaymentStatus;
                isPurchaseDetailExist.IsActive = true;




                dbcontext.Entry(isPurchaseDetailExist);
                dbcontext.SaveChanges();
            }


        }




        public PurchaseMedicineViewModel GetPurchasesByPurchaseMedicineId(int purchaseMedicineId)
        {
            var result = dbcontext.PurchaseDetails.Where(x => x.IsActive && x.PurchaseMedicineId == purchaseMedicineId).Select(s => new PurchaseMedicineViewModel()
            {
                PurchaseMedicineId = s.PurchaseMedicineId,
                SupplierName = s.SupplierName,
                Code = s.Code,

                Date = s.Date,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                MedicineDesc = dbcontext.Master_Medicine.Where(x => x.MedicineId == s.Medicine).Select(b => b.Description).FirstOrDefault(),
                Medicine = s.Medicine,
                Quantity = s.Quantity,
                Notes = s.Notes,
                Discount = s.Discount,
                GrandTotal = s.GrandTotal,
                PaymentMethod = dbcontext.Master_Payment.Where(x => x.PaymentId == s.Payment).Select(b => b.Method).FirstOrDefault(),
                Payment = s.Payment,
                PaymentStatusMethod = dbcontext.Master_PaymentStatus.Where(x => x.PaymentStatusId == s.Status).Select(b => b.Method).FirstOrDefault(),
                PaymentStatus = s.Status,

                IsActive = s.IsActive,



            }).FirstOrDefault();


            return result;
        }

            



        }
}