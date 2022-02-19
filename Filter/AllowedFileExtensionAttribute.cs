using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Filter
{
    public class AllowedFileExtensionAttribute : ValidationAttribute
    {
        public string[] AllowedFileExtensions { get; private set; }
        public AllowedFileExtensionAttribute(params string[] allowedFileExtensions)
        {
            AllowedFileExtensions = allowedFileExtensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                if (!AllowedFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase)))
                {
                    return new ValidationResult(string.Format("{1} için izin verilen dosya uzantıları : {0} : {2}", string.Join(", ", AllowedFileExtensions), validationContext.DisplayName, this.ErrorMessage));
                }
            }
            return null;
        }
    }
}