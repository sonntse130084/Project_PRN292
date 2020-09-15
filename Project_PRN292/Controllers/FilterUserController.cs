using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_PRN292.Controllers
{
    public class FilterUserController : Controller
    {
        // GET: FilterUser
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = Session["USER"] as Model.EF.User;
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Login", action = "Index", area = "" }
                ));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}