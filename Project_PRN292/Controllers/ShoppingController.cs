using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: Shopping
        public ActionResult Index()
        {
            PhoneDAO dao = new PhoneDAO();
            Session["MANAGE"] = "Shop";
            ViewData["PHONE"] = dao.GetAllCurrentPhone();
            return View();
        }

        public ActionResult ViewBySupplier(string supID)
        {
            PhoneDAO dao = new PhoneDAO();
            SupplierDAO daoSup = new SupplierDAO();
            Session["MANAGE"] = "Shop";
            ViewData["SUPPLIER"] = daoSup.GetSupplier(supID);
            ViewData["PHONE"] = dao.GetAllCurrentPhoneBySup(supID);
            return View("Index");
        }
    }
}