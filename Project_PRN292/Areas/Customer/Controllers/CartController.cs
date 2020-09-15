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
    public class CartController : FilterController
    {
        // GET: Customer/Cart
        public ActionResult Index()
        {
            Session["MANAGE"] = "Cart";
            return View();
        }

        public JsonResult AddToCart(string phoneID)
        {
            CartObj cart = (CartObj)Session["CART"];
            if (cart == null)
            {
                cart = new CartObj();
            }
            cart.AddToCart(phoneID);
            Session["CART"] = cart;
            List<dynamic> x = new List<dynamic>();
            x.Add(cart.cart.Count);
            x.Add(cart.total);
            return Json(x);
        }

        public JsonResult UpdateCart(string phoneID, int value)
        {
            PhoneDAO dao = new PhoneDAO();
            Phone phone = dao.GetPhone(phoneID);
            CartObj cart = (CartObj)Session["CART"];
            if (cart == null)
            {
                cart = new CartObj();
            }
            cart.UpdateCart(phoneID, value);
            Session["CART"] = cart;
            List<dynamic> x = new List<dynamic>();
            x.Add(cart.cart.Count);
            x.Add(cart.total);
            x.Add(cart.cart[phone] * phone.price);
            return Json(x);
        }

        public JsonResult AddToCartWithValue(string phoneID, int value)
        {
            PhoneDAO dao = new PhoneDAO();
            Phone p = dao.GetPhone(phoneID);
            CartObj cart = (CartObj)Session["CART"];
            if (cart == null)
            {
                cart = new CartObj();
            }
            cart.AddToCart(phoneID, value);
            Session["CART"] = cart;
            List<dynamic> x = new List<dynamic>();
            x.Add(cart.cart.Count);
            x.Add(cart.total);
            x.Add(p.quantity - cart.cart[p]);
            return Json(x);
        }

        public ActionResult RemoveCart(string phoneID)
        {
            CartObj cart = (CartObj)Session["CART"];
            if (cart == null)
            {
                cart = new CartObj();
            }
            cart.RemoveCart(phoneID);
            Session["CART"] = cart;
            return View("Index");
        }
    }
}