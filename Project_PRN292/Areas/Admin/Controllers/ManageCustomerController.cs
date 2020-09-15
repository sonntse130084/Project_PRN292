using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Areas.Admin.Controllers
{
    public class ManageCustomerController : FilterController
    {
        // GET: Admin/ManageCustomer
        public ActionResult Index()
        {
            Session["MANAGE"] = "Customer";
            UserDAO dao = new UserDAO();
            List<User> list = dao.GetAllCustomer();
            ViewData["All"] = list;
            return View();
        }

        public ActionResult Delete(string username)
        {
            UserDAO dao = new UserDAO();
            dao.Delete(username);
            return RedirectToAction("Index", "ManageCustomer");
        }

        public ActionResult Insert(string username1,string password1, string fullname1, string address1,string email1,string phone1 , HttpPostedFileBase FileAva)
        {
            string avatar = "/Image/defaultAva.png";
            if (FileAva != null) { 
                string path = Server.MapPath("~/Image/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (FileAva != null)
                {
                    string fileName = Path.GetFileName(FileAva.FileName);
                    FileAva.SaveAs(path + fileName);
                    avatar = "/Image/" + fileName;

                }
            }
            UserDAO dao = new UserDAO();
            bool result = dao.Insert(new User() 
            { username = username1,password=password1,fullName=fullname1,address=address1,email=email1,phone=phone1,status=true,avatar=avatar,roleID= "R2"});
            return RedirectToAction("Index", "ManageCustomer");

        }

        public JsonResult CheckDupUsername(string username)
        {
            System.Threading.Thread.Sleep(1500);
            UserDAO dao = new UserDAO();
            User user = dao.GetUser(username);
            if (user != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public ActionResult ViewUpdate(string username)
        {
            UserDAO dao = new UserDAO();
            ViewData["UPDATE"] = dao.GetUser(username);
            return View();
        }
        [HttpPost]
        public ActionResult Update(User user, HttpPostedFileBase FileAva)
        {
            if (FileAva != null)
            {
                string path = Server.MapPath("~/Image/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (FileAva != null)
                {
                    string fileName = Path.GetFileName(FileAva.FileName);
                    FileAva.SaveAs(path + fileName);
                    user.avatar = "/Image/" + fileName;

                }
            }
            UserDAO dao = new UserDAO();
            dao.Update(user);
            return RedirectToAction("Index", "ManageCustomer");
        }
    }
}