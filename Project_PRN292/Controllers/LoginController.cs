using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(User user)
        {
            UserDAO dao = new UserDAO();
            bool result = dao.Login(user.username, user.password);
            if (result)
            {
                User u = dao.GetUser(user.username);
                Session.Add("USER", u);
                Session.Add("MANAGE", "Customer");
                if (u.roleID.Equals("R1"))
                {
                    return RedirectToAction("Index", "Admin/ManageCustomer");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewData["MsgErr"] = "Invalid username or password";
            return View("Index");
        }
    }
}