using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PurchaseMedicineController : Controller
    {
        // GET: PurchaseMedicine
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> MedicineList { get; set; }
        public List<SelectListItem> PaymentStatusList { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
        public List<SelectListItem> PaymentList { get; set; }

        public ActionResult Purchase()
            {
            var ViewModel = new PurchaseMedicineViewModel();
            ViewModel.MedicineList = GetMedicineList();

            ViewModel.CategoryList = GetCategoryList();
            ViewModel.PaymentList = GetPaymentList();

            ViewModel.PaymentStatusList = GetPaymentStatusList();
            return View(ViewModel);
        }
        public ActionResult PurchaseMedicine(PurchaseMedicineViewModel model)
        {
            var purchaseMedicineRepository = new PurchaseMedicineRepository();
            if (model.MedicineId == default(int))
            {
                purchaseMedicineRepository.PurchaseMedicineDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Purchase");
            }
            else
            {
                purchaseMedicineRepository.PurchaseDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult GetPurchaseMedicineList(JQGridSort jQGridSort)                   
        {
            var purchaseMedicineRepository = new PurchaseMedicineRepository();
            var result = purchaseMedicineRepository.GetPurchaseMedicineList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int medicineId)
        {
            var purchaseMedicineRepository = new PurchaseMedicineRepository();
            purchaseMedicineRepository.PurchaseMedicineDeletion(medicineId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        public ActionResult UpdatePurchaseMedicine(string id = null)
        {
            int medicineId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out medicineId);
            }
            var model = new PurchaseMedicineViewModel();
            var purchaseMedicineRepository = new PurchaseMedicineRepository();
            model = purchaseMedicineRepository.GetPurchaseMedicineByPurchaseMedicineDetailId(medicineId);
            model.MedicineList = GetMedicineList();

            model.CategoryList = GetCategoryList();
            model.PaymentList = GetPaymentList();

            model.PaymentStatusList = GetPaymentStatusList();

            return View(model);

        }
        private List<SelectListItem> GetMedicineList()
        {
            var medicineSelectList = new List<SelectListItem>();
            var mastermedicineRepository = new MasterMedicineRepository();
            var medicineList = mastermedicineRepository.GetMedicineList();

            foreach (var item in medicineList)
            {
                medicineSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.MedicineId.ToString() });
            }
            return medicineSelectList;
        }
        private List<SelectListItem> GetPaymentStatusList()
        {
            var statusSelectList = new List<SelectListItem>();
            var masterstatusRepository = new MasterPaymentStatusRepository();
            var statusList = masterstatusRepository.GetPaymentStatusList();

            foreach (var item in statusList)
            {
                statusSelectList.Add(new SelectListItem() { Text = item.Method, Value = item.PaymentStatusId.ToString() });
            }
            return statusSelectList;
        }
        private List<SelectListItem> GetCategoryList()
        {
            var categorySelectList = new List<SelectListItem>();
            var mastercategoryRepository = new MasterCategoryRepository();
            var categoryList = mastercategoryRepository.GetCategoryList();

            foreach (var item in categoryList)
            {
                categorySelectList.Add(new SelectListItem() { Text = item.Description, Value = item.CategoryId.ToString() });
            }
            return categorySelectList;
        }
        private List<SelectListItem> GetPaymentList()
        {
            var paymentSelectList = new List<SelectListItem>();
            var masterpaymentRepository = new MasterPaymentRepository();
            var paymentList = masterpaymentRepository.GetPaymentList();

            foreach (var item in paymentList)
            {
                paymentSelectList.Add(new SelectListItem() { Text = item.Method, Value = item.PaymentId.ToString() });
            }
            return paymentSelectList;
        }
        //insert

       
    }
}