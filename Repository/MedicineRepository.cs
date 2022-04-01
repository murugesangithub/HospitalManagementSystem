using System;
using System.Data;
using System.Linq;
using HospitalManagementSystem.Common;
using HospitalManagementSystem.Entity;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;

namespace HospitalManagementSystem.DataAccess.Repository
{
    public class MedicineRepository : BaseRepository
    {

        //insert
        public void MedicineDetailInsertion(MedicineViewModel medicineViewModel)
        {
            MedicineDetail medicineDetail = new MedicineDetail()
            {
                MedicineId = medicineViewModel.MedicineId,
                MedicineName = medicineViewModel.MedicineName,
                Category = medicineViewModel.Category,
                CompanyName = medicineViewModel.CompanyName,
                PurchaseDate = medicineViewModel.PurchaseDate,
                Price = medicineViewModel.Price,
                ExpiredDate = medicineViewModel.ExpiredDate,
                Stock = medicineViewModel.Stock,
                IsActive = true,
            };
            dbcontext.MedicineDetails.Add(medicineDetail);
            dbcontext.SaveChanges();
        }


        //update

        public void MedicineDetailUpdation(MedicineViewModel medicineViewModel)
        {
            var isMedicineDetailExist = dbcontext.MedicineDetails.Where(x => x.IsActive && x.MedicineId == medicineViewModel.MedicineId).FirstOrDefault();
            if (isMedicineDetailExist != null)
            {
                isMedicineDetailExist.MedicineName = medicineViewModel.MedicineName;
                isMedicineDetailExist.Category = medicineViewModel.Category;
                isMedicineDetailExist.CompanyName = medicineViewModel.CompanyName;
                isMedicineDetailExist.PurchaseDate = medicineViewModel.PurchaseDate;
                isMedicineDetailExist.Price = medicineViewModel.Price;
                isMedicineDetailExist.ExpiredDate = medicineViewModel.ExpiredDate;
                isMedicineDetailExist.Stock = medicineViewModel.Stock;
                isMedicineDetailExist.IsActive = true;
                dbcontext.Entry(isMedicineDetailExist);
                dbcontext.SaveChanges();
            }

        }


        //select

        public JQGridResponse<MedicineViewModel> GetMedicineList(JQGridSort jQGridSort)
        {
            IQueryable<MedicineViewModel> list = GetMedicineListQuery();
            var predicate = JQGridSorting.GeneratePredicate<MedicineViewModel>(jQGridSort);
            var result = JqGridResult.GridFilteration(jQGridSort, list.Where(predicate).ToList());
            return result;
        }
        public IQueryable<MedicineViewModel> GetMedicineListQuery()
        {
            var result = dbcontext.MedicineDetails.Where(x => x.IsActive).Select(s => new MedicineViewModel()
            {
                MedicineId = s.MedicineId,
                MedicineName = s.MedicineName,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                CompanyName = s.CompanyName,
                PurchaseDate = s.PurchaseDate,
                Price = s.Price,
                ExpiredDate = s.ExpiredDate,
                Stock = s.Stock,
                IsActive = s.IsActive,

            }).ToList();

            result.ForEach(x => x.EncryptMedicineId = Cryptography.EncryptStringToBytes_Aes(x.MedicineId.ToString()));

            return result.AsQueryable();
        }

        public MedicineViewModel GetMedicineByMedicineDetailId(int medicineId)
        {
            var result = dbcontext.MedicineDetails.Where(x => x.IsActive && x.MedicineId == medicineId).Select(s => new MedicineViewModel()
            {
                MedicineId = s.MedicineId,
                MedicineName = s.MedicineName,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                CompanyName = s.CompanyName,
                PurchaseDate = s.PurchaseDate,
                Price = s.Price,
                ExpiredDate = s.ExpiredDate,
                Stock = s.Stock,
                IsActive = s.IsActive,


            }).FirstOrDefault();


            return result;
        }

        //delete
        public void MedicineDeletion(int medicineId)
        {
            var medicinedetail = dbcontext.MedicineDetails.Where(x => x.IsActive && x.MedicineId == medicineId).FirstOrDefault();
            if (medicinedetail != null)
            {
                medicinedetail.IsActive = false;
                dbcontext.Entry(medicinedetail);
                dbcontext.SaveChanges();
            }
        }

        public MedicineViewModel GetMedicineDetail(int MedicineId)
        {
            var result = dbcontext.MedicineDetails.Where(x => x.IsActive).Select(s => new MedicineViewModel()
            {
                MedicineId = s.MedicineId,
                MedicineName = s.MedicineName,
                CategoryDesc = dbcontext.Master_Category.Where(x => x.CategoryId == s.Category).Select(b => b.Description).FirstOrDefault(),
                Category = s.Category,
                CompanyName = s.CompanyName,
                PurchaseDate = s.PurchaseDate,
                Price = s.Price,
                ExpiredDate = s.ExpiredDate,
                Stock = s.Stock,
                IsActive = s.IsActive,

            }).FirstOrDefault();

            return result;
        }
    }
}