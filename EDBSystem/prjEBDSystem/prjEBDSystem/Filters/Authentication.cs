using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjEBDSystem.Filters
{
    public class Authentication : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Login"
            };
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                string isAutenticado = httpContext.Request.Cookies["User"].Value;

                if (!string.IsNullOrEmpty(isAutenticado) && isAutenticado.Split('/').FirstOrDefault() == "True")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}