using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class SignoutController : Controller
    {
        // GET: Signout
        public ActionResult Index()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}