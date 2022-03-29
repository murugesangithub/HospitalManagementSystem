using HospitalManagementSystem.Filter;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace HospitalManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Role")]
        public List<System.Web.Mvc.SelectListItem> RoleList { get; set; } = new List<System.Web.Mvc.SelectListItem>();
        public int Role { get; set; }
        public bool IsActive { get; set; }
        public int UserDetailId { get; set; }
        public string RoleDesc { get; set; }
        [Display(Name = "Profile Image")]
        [AllowedFileExtension(".jpg", ".png", ".gif", ".jpeg", ".jfif")]
        public HttpPostedFileBase ImageFileUpload { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        public string EncryptUserDetailId { get; set; }
    }
}