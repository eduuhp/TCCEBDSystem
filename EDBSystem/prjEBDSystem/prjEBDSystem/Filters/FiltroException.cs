using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjEBDSystem.Filters
{
    public class FiltroException : HandleErrorAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            

            if (filterContext.HttpContext.Request.Cookies["User"] == null)
            {
                filterContext.Result = new RedirectResult("~/Login/ConfirmLogin");
            }
            else
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    TempData = new TempDataDictionary { { "Error", filterContext.Exception.Message }, { "Pilha", filterContext.Exception.StackTrace } },
                };
            }
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
        }
    }
}