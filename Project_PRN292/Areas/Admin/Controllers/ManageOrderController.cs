using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Project_PRN292.Areas.Admin.Controllers
{
    public class ManageOrderController : FilterController
    {
        // GET: Admin/ManageOrder
        public ActionResult Index()
        {
            Session["MANAGE"] = "Order";
            OrderDAO dao = new OrderDAO();
            List<Order> list = dao.GetAllOrder();
            ViewData["All"] = list;
            return View();
        }

        public ActionResult ViewDetails(string orderID)
        {
            int id = int.Parse(orderID);
            OrderDAO dao = new OrderDAO();
            ViewData["ORDER"] = dao.GetOrder(id) ;
            return View();
        }
    }
}