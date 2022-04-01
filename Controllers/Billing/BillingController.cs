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
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }
        public List<SelectListItem> DepartmentList { get; set; }
        public List<SelectListItem> PaymentList { get; set; }
        public List<SelectListItem> ServiceList { get; set; }
        public List<SelectListItem> PaymentStatusList { get; set; }

        public ActionResult Add()
        {
            var ViewModel = new BillingViewModel();
            ViewModel.DepartmentList = GetDepartmentList();
            ViewModel.PaymentList = GetPaymentList();
            ViewModel.PaymentStatusList = GetPaymentStatusList();
            ViewModel.ServiceList = GetServiceList();
            return View(ViewModel);
        }
        private List<SelectListItem> GetDepartmentList()
        {
            var departmentSelectList = new List<SelectListItem>();
            var masterdepartmentRepository = new MasterDepartmentRepository();
            var departmentList = masterdepartmentRepository.GetDepartmentList();

            foreach (var item in departmentList)
            {
                departmentSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.DepartmentId.ToString() });
            }
            return departmentSelectList;
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
        private List<SelectListItem> GetServiceList()
        {
            var ServiceSelectList = new List<SelectListItem>();
            var masterserviceRepository = new MasterServiceRepository();
            var serviceList = masterserviceRepository.GetServiceList();

            foreach (var item in serviceList)
            {
                ServiceSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.ServiceId.ToString() });
            }
            return ServiceSelectList;
        }
        private List<SelectListItem> GetPaymentStatusList()
        {
            var PaymentStatusSelectList = new List<SelectListItem>();
            var masterpaymentstatusRepository = new MasterPaymentStatusRepository();
            var paymentstatusList = masterpaymentstatusRepository.GetPaymentStatusList();

            foreach (var item in paymentstatusList)
            {
                PaymentStatusSelectList.Add(new SelectListItem() { Text = item.Method, Value = item.PaymentStatusId.ToString() });
            }
            return PaymentStatusSelectList;
        }
        public ActionResult AddBilling(BillingViewModel model)
        {

            var billingRepository = new BillingRepository();
            if (model.PatientId == default(int))
            {
                billingRepository.BillingDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {

                billingRepository.BillingDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult GetBillingList(JQGridSort jQGridSort)
        {
            var billingRepository = new BillingRepository();
            var result = billingRepository.GetBillingList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int patientId)
        {
            var billingRepository = new BillingRepository();
            billingRepository.BillingDeletion(patientId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        public ActionResult UpdateBillingDetail(string id = null)
        {
            int patientId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var model = new BillingViewModel();
            var billingRepository = new BillingRepository();
            model = billingRepository.GetBillingByBillingDetailId(patientId);
            model.DepartmentList = GetDepartmentList();
            model.PaymentList = GetPaymentList();
            model.ServiceList = GetServiceList();
            model.PaymentStatusList = GetPaymentStatusList();

            return View(model);

        }
        public ActionResult GetBillingDetail(string id)
        {
            int patientId = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientId);
            }
            var billingRepository = new BillingRepository();
            var result = billingRepository.GetBillingDetail(patientId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}