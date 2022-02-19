using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HospitalManagementSystem.Filter
{

    public class ExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            //var reportRepository = new ReportRepository();

            //var errorLogViewModel = new ErrorLogViewModel()
            //{
            //    Subject = filterContext.Exception.Message,
            //    Description = filterContext.Exception.StackTrace,
            //    IPAddress = GetIp()

            //};
            //reportRepository.ErrorLogInsertion(errorLogViewModel);
            //var model = new HandleErrorInfo(filterContext.Exception, "Home", "Error");

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
              //  ViewData = new ViewDataDictionary(model)
            };
        }
        public string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

    }

}