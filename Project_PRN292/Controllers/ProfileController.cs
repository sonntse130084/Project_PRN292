using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_PRN292.Controllers
{
    public class ProfileController : FilterUserController
    {
        // GET: Profile
        public ActionResult Index()
        {
            //RoleDAO dao = new RoleDAO();
            //ViewData["ROLE_LIST"] = dao.RoleList();
            return View();
        }

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
            Session["User"] = dao.GetUser(user.username);
            return View("Index");
        }

        public ActionResult UpdatePassword(string newPWD, string username)
        {

            UserDAO dao = new UserDAO();
            dao.UpdatePassword(newPWD, username);
            Session["User"] = dao.GetUser(username);
            return View("Index");
        }

        public JsonResult CheckPassword(string oldPWD)
        {
            User user = Session["User"] as User;
            if (user.password.Equals(oldPWD))
            {
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }
    }
}