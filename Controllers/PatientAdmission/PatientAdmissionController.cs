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
    public class PatientAdmissionController : Controller
    {
        // GET: PatientAdmission
        public ActionResult PatientAdmit()
        {
            return View();
        }
        public ActionResult AddAdmission()
        {
            return View();
        }

        public ActionResult PatientAdmitForm(PatientAdmissionViewModel model)
        {

            var patientAdmissionRepository = new PatientAdmissionRepository();
            if (model.PatientAdmissionId == default(int))
            {
                patientAdmissionRepository.PatientAdmitFormInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("PatientAdmit");
            }
            else
            {


                patientAdmissionRepository.PatientAdmissionUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("AddAdmission");
            }

            return View();
        }


        //select grid
        public ActionResult GetPatientAdmissionList(JQGridSort jQGridSort)
        {
            var patientAdmissionRepository = new PatientAdmissionRepository();
            var result = patientAdmissionRepository.GetPatientAdmissionList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //delete

        public ActionResult Delete(int patientAdmissionId)
        {
            var patientAdmissionRepository = new PatientAdmissionRepository();
            patientAdmissionRepository.PatientAdmissionDeletion(patientAdmissionId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }



        //update


        //public ActionResult UpdatePatientAdmitForm(string id = null)
        //{
        //    int patientAdmissionId = default(int);

        //    if (!string.IsNullOrEmpty(id))
        //    {
        //        int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientAdmissionId);
        //    }

        //    var patientAdmissionRepository = new PatientAdmissionRepository();
        //    var model = patientAdmissionRepository.GetPatientsByPatientAdmissionId(patientAdmissionId);


        //    return View(model);
        //}




        public ActionResult UpdatePatientAdmission(string id = null)
        {
            int patientAdmissionId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out patientAdmissionId);
            }

            var patientAdmissionRepository = new PatientAdmissionRepository();
            var model = patientAdmissionRepository.GetPatientAdmitedByPatientAdmissionId(patientAdmissionId);


            return View(model);
        }

    }
}