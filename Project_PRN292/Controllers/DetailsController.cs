using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult Index(string phoneID)
        {
            PhoneDAO dao = new PhoneDAO();
            Phone phone = dao.GetPhone(phoneID);
            ViewData["PHONE"] = phone;
            return View();
        }
    }
}