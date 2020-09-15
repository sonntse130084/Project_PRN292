using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Areas.Customer.Controllers
{
    public class ViewOrderHistoryController : Controller
    {
        // GET: Customer/ViewOrderHistory
        public ActionResult Index()
        {
            Session["MANAGE"] = "Order";
            User user = (User)Session["USER"];
            if (user != null)
            {
                OrderDAO dao = new OrderDAO();
                List<Order> list = dao.GetAllOrderOfUser(user);
                ViewData["All"] = list;
            }
            return View();

        }

        public ActionResult ViewDetails(string orderID)
        {
            int id = int.Parse(orderID);
            OrderDAO dao = new OrderDAO();
            ViewData["ORDER"] = dao.GetOrder(id);
            return View();
        }
    }
}