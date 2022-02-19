using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace HospitalManagementSystem.Filter
{


    public class Authorization : AuthorizeAttribute
    {

        public Authorization()
        {
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            //var session = httpContext.Session[AppConstant.UserDetail];

            //if (session != null)
            //{

            //    var userDetail = (RegisterViewModel)session;
            //    var authorizedRoles = Roles.Split(',');
            //    if (Array.IndexOf(authorizedRoles, userDetail.RoleDesc) > -1)
            //    {
            //        authorize = true;

            //    }
            //    else
            //    {
            //        authorize = false;
            //    }

            //}
           

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var action = "Unauthorized";
            
            //if (filterContext.HttpContext.Session[AppConstant.UserDetail] == null)
            //{
            //    action = "Login";
            //}
          
            filterContext.Result = new RedirectToRouteResult(
             new RouteValueDictionary
             {
                    { "controller", "Account" },
                    { "action", action }
             });

        }
    }

}