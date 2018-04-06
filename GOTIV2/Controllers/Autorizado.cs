using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GOTIV2.Controllers
{
    public class Autorizado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UsuarioLogueado"] == null)
            {

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JavaScriptResult();
                    ((JavaScriptResult)filterContext.Result).Script = string.Format("window.location.href='{0}'", new UrlHelper(filterContext.RequestContext).Action("Login", "Cuenta"));

                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                                                                                { "Controller", "Cuenta" },
                                                                                { "Action", "Login" }
                                                                            });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}