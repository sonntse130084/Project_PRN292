using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_PRN292.Areas.Customer.Controllers
{
    public class FilterController : Controller
    {
        // GET: Customer/Filter
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = Session["USER"] as Model.EF.User;
            if (user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Login", action = "Index", area = "" }
                ));
            }
            else if( user.roleID.Equals("R1"))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "ManageCustomer", action = "Index", area = "Admin" }
                ));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}