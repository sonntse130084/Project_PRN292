using Model.DAO;
using Model.EF;
using Project_PRN292.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Areas.Customer.Controllers
{
    public class CheckoutController : FilterController
    {
        // GET: Customer/Checkout
        public ActionResult Index()
        {
            Session["MANAGE"] = "Cart";
            return View();
        }

        public ActionResult Checkout(string receiver, string phone, string address)
        {
            User user = (User)Session["USER"];
            if (user != null)
            {
                CartObj cart = (CartObj)Session["CART"];
                if (cart != null)
                {
                    DateTime date = DateTime.Now;
                    OrderDAO daoOrder = new OrderDAO();
                    OrderDetailsDAO daoDetails = new OrderDetailsDAO();
                    Order order = new Order() { phone = phone, receiver = receiver, addressShip = address, username = user.username, orderDate= date};
                    daoOrder.Add(order);
                    int currentID = daoOrder.GetCurrentOrderID();
                    foreach(var item in cart.cart)
                    {
                        OrderDetail details = new OrderDetail()
                        {
                            orderID = currentID,
                            phoneID = item.Key.phoneID,
                            price = item.Key.price,
                            quantity = item.Value,
                            discount = item.Key.discount
                        };
                        daoDetails.Add(details);
                        PhoneDAO daoPhone = new PhoneDAO();
                        daoPhone.UpdateQuantity(item.Value,item.Key.phoneID);
                    }
                    Session["CART"] = null;
                }
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}