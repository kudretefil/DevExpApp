using DXWebApplication1.Infrastructure.EntityException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Infrastructure
{
    public class EntityErrorAttribute : HandleErrorAttribute
    {
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            string errorMessage = filterContext.Exception.Message;
            EntityContext.Logger.Fatal(errorMessage, filterContext.Exception);

            if (filterContext.Exception is EntityBusinessException)
                errorMessage = filterContext.Exception.Message;
            else
                errorMessage = "An unexpected error occured.Please retry later.";

            if (IsAjax(filterContext))
            {
                filterContext.Result = new JsonResult()
                {
                    Data = new
                    {
                        Passed = false,
                        Message = errorMessage
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

            }
            else
            {
                filterContext.Controller.TempData["AppError"] = errorMessage;
                filterContext.Result = new RedirectResult("~/Error");
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];
        }
    }
}