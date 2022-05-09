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
    public class MedicineController : Controller
    {
        // GET: Medicine
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> CategoryList { get;  set; }
        public ActionResult Add()
        {
           
            var ViewModel = new MedicineViewModel();

            ViewModel.CategoryList = GetCategoryList();

            return View(ViewModel);
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
        public ActionResult AddMedicine(MedicineViewModel model)
        {

            var medicineRepository = new MedicineRepository();
            if (model.MedicineId == default(int))
            {
                medicineRepository.MedicineDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {


                medicineRepository.MedicineDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }

            return View();

        }
        public ActionResult GetMedicineList(JQGridSort jQGridSort)
        {
            var medicineRepository = new MedicineRepository();
            var result = medicineRepository.GetMedicineList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int medicineId)
        {
            var medicineRepository = new MedicineRepository();
            medicineRepository.MedicineDeletion(medicineId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        public ActionResult UpdateMedicineDetail(string id = null)
        {
            int medicineId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out medicineId);
            }

            var model = new MedicineViewModel();
            var medicineRepository = new MedicineRepository();

            model = medicineRepository.GetMedicineByMedicineDetailId(medicineId);

            model.CategoryList = GetCategoryList();

            return View(model);

        }
        public ActionResult GetMedicineDetail(string id)
        {
            int medicineId = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out medicineId);
            }
            var medicineRepository = new MedicineRepository();
            var result = medicineRepository.GetMedicineDetail(medicineId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}