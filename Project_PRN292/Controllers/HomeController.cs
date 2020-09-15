using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            PhoneDAO dao = new PhoneDAO();
            SupplierDAO daoSup = new SupplierDAO();
            ViewData["PHONE"] = dao.GetLastestPhone();
            ViewData["SUPPLIER"] = daoSup.GetAllSupplier();
            Session["MANAGE"] = "Home";
            return View();
        }
    }
}