using HospitalManagementSystem.Common;
using HospitalManagementSystem.DataAccess.Repository;
using HospitalManagementSystem.JqGrid;
using HospitalManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers.User
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult GetUserList(JQGridSort jQGridSort)
        {
            var accountRepository = new AccountRepository();
            var result = accountRepository.GetUserList(jQGridSort);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(string id = null)
        {
            int userDetailId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out userDetailId);
            }
            var model = new RegisterViewModel();
            var accountRepository = new AccountRepository();
            if (userDetailId != default(int))
            {
                model = accountRepository.GetUserByUserDetailId(userDetailId);


            }
            model.RoleList = GetRoles();
            model.GenderList = GetGenderList();
            model.StateList = GetStateList();
            model.DesignationList = GetDesignationList();
            model.SpecialistList = GetSpecialistList();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RegisterViewModel model)
        {

            byte[] bytes = null;
            if (model.ImageFileUpload != null)
            {
                using (BinaryReader br = new BinaryReader(model.ImageFileUpload.InputStream))
                {
                    bytes = br.ReadBytes(model.ImageFileUpload.ContentLength);
                }
                model.ProfileImage = "data:image/" + model.ImageFileUpload.ContentType + ";base64," + Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            //model.FileContentType = model.ImageFile.ContentType;

            var accountRepository = new AccountRepository();

            if (model.UserDetailId == default(int))
            {
                var emailExist = accountRepository.IsUserExistforInsert(model.Email);
                if (emailExist)
                {
                    ModelState.AddModelError("", "Email is already exist");
                    model.RoleList = GetRoles();
                 
                    return View(model);
                }


                accountRepository.UserDetailInsertion(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Add");
            }
            else
            {
                var emailExist = accountRepository.IsUserExistforUpdate(model.UserDetailId, model.Email);
                if (emailExist)
                {
                    ModelState["Password"].Errors.Clear();
                    ModelState.AddModelError("", "Email is already exist");
                    model.RoleList = GetRoles();
                    return View("UpdateUserDetail", model);
                }
                accountRepository.UserDetailUpdation(model);
                TempData[AppConstant.Response] = AppConstant.Success;
                return RedirectToAction("Index");
            }
        }

        public ActionResult ResetPassword(string id = null)
        {
            int userDetailId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out userDetailId);
            }
            var accountRepository = new AccountRepository();
            var userdetail = accountRepository.GetUserByUserDetailId(userDetailId);
            var resetpasswordModel = new ResetPasswordViewModel()
            {
                UserDetailId = userdetail.UserDetailId,
                Email = userdetail.Email,
            };

            return View(resetpasswordModel);
        }
        public ActionResult UpdatePassword(ResetPasswordViewModel resetpasswordmodel)
        {
            if (ModelState.IsValid)
            {
                var accountRepository = new AccountRepository();
                accountRepository.UpdatePassword(resetpasswordmodel);
                TempData[AppConstant.Response] = AppConstant.Success;
            }
            return View("Index");
        }

        public ActionResult UpdateUserDetail(string id = null)
        {
            int userDetailId = default(int);

            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out userDetailId);
            }
            var model = new RegisterViewModel();
            var accountRepository = new AccountRepository();
            model = accountRepository.GetUserByUserDetailId(userDetailId);
            model.RoleList = GetRoles();
            return View(model);
        }

        public ActionResult Delete(int userDetailId)
        {
            var accountRepository = new AccountRepository();
            accountRepository.UserDeletion(userDetailId);
            return Json(new AjaxResponse() { IsSuccess = true });
        }

        private static List<SelectListItem> GetRoles()
        {
            var result = new List<SelectListItem>();
            var typelist = new AccountRepository().GetRoleQuery().ToList();
            foreach (var item in typelist)
            {
                result.Add(new SelectListItem() { Value = item.RoleId.ToString(), Text = item.Description });
            }

            return result;
        }
        private List<SelectListItem> GetGenderList()
        {
            var genderSelectList = new List<SelectListItem>();

            var mastergenderRepository = new MasterGenderRepository();
            var genderList = mastergenderRepository.GetGenderList();

            foreach (var item in genderList)
            {
                genderSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.GenderId.ToString() });
            }
            return genderSelectList;
        }

        private List<SelectListItem> GetStateList()
        {
            var stateSelectList = new List<SelectListItem>();

            var masterStateRepository = new MasterStateRepository();
            var stateList = masterStateRepository.GetStatelist();

            foreach (var item in stateList)
            {
                stateSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.StateId.ToString() });
            }

            return stateSelectList;
        }

        private List<SelectListItem> GetSpecialistList()
        {
            var specialistSelectList = new List<SelectListItem>();

            var masterspecialistRepository = new MasterSpecialistRepository();
            var specialistList = masterspecialistRepository.GetSpecialistlist();

            foreach (var item in specialistList)
            {
                specialistSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.SpecialistId.ToString() });
            }

            return specialistSelectList;
        }
        private List<SelectListItem> GetDesignationList()
        {
            var designationSelectList = new List<SelectListItem>();

            var masterdesignationRepository = new MasterDesignationRepository();
            var designationList = masterdesignationRepository.GetDesignationList();

            foreach (var item in designationList)
            {
                designationSelectList.Add(new SelectListItem() { Text = item.Description, Value = item.DesignationId.ToString() });
            }

            return designationSelectList;
        }
        public ActionResult GetUserDetail(string id)
        {
            int userDetailId = default(int);
            if (!string.IsNullOrEmpty(id))
            {
                int.TryParse(Cryptography.DecryptStringFromBytes_Aes(id), out userDetailId);
            }
            var accountRepository = new AccountRepository();
            var result = accountRepository.GetUserDetail(userDetailId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}