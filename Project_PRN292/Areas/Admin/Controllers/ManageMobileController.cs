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
    public class ManageMobileController : FilterController
    {
        // GET: Admin/ManageMobile
        public ActionResult Index()
        {
            Session["MANAGE"] = "Mobile";
            PhoneDAO daoPhone = new PhoneDAO();
            SupplierDAO daoSup = new SupplierDAO();
            List<Phone> listMobile = daoPhone.GetAllPhone();
            List<Supplier> listSupplier = daoSup.GetAllSupplier();
            ViewData["All_MOBILE"] = listMobile;
            ViewData["All_Supplier"] = listSupplier;

            return View();
        }
        public ActionResult Delete(string phoneID)
        {
            PhoneDAO dao = new PhoneDAO();
            dao.Delete(phoneID);
            return RedirectToAction("Index", "ManageMobile");
        }
        public ActionResult Insert(string phoneID1, string phoneName1, string description1, string quantity1, string price1, string discount1, string supID1)
        {
            double discount = 0;
            if(discount1.Length>0)
            {
                discount = double.Parse(discount1);
            }
            PhoneDAO dao = new PhoneDAO();
            PhotoPhoneDAO daoPhoto = new PhotoPhoneDAO();
            bool result = dao.Insert(new Phone()
            {
                phoneID= phoneID1,phoneName=phoneName1,description = description1,price=double.Parse(price1),quantity=int.Parse(quantity1),discount =discount,supID=supID1,status = true
            });
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase f = Request.Files[i];
                if (f.ContentLength > 0)
                {
                    daoPhoto.Insert(new PhotoPhone()
                    {
                        urlPhoto = "/Image/" + f.FileName,
                        phoneID = phoneID1
                    });
                    f.SaveAs(Server.MapPath("~/Image/") + f.FileName);
                }
            }
            return RedirectToAction("Index", "ManageMobile");
        }

        public JsonResult CheckDupMobileID(string phoneID)
        {
            System.Threading.Thread.Sleep(1500);
            PhoneDAO dao = new PhoneDAO();
            Phone phone = dao.GetPhone(phoneID);
            if (phone != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public ActionResult ViewUpdate(string phoneID)
        {
            SupplierDAO dao = new SupplierDAO();
            PhotoPhoneDAO daoPhoto = new PhotoPhoneDAO();
            PhoneDAO daoPhone = new PhoneDAO();
            ViewData["SUPPLIER_LIST"] = dao.GetAllSupplier();
            ViewData["UPDATE"] = daoPhone.GetPhone(phoneID);
            ViewData["PHOTO"] = daoPhoto.GetPhotoOfPhone(phoneID);
            return View();
        }

        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            PhoneDAO dao = new PhoneDAO();
            PhotoPhoneDAO daoPhoto = new PhotoPhoneDAO();
            dao.Update(phone);
            if (Request.Files[0].ContentLength > 0)
            {
                daoPhoto.DeletePhotoOfPhone(phone.phoneID);
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase f = Request.Files[i];
                    if (f.ContentLength > 0)
                    {
                        daoPhoto.Insert(new PhotoPhone()
                        {
                            urlPhoto = "/Image/" + f.FileName,
                            phoneID = phone.phoneID
                        });
                        f.SaveAs(Server.MapPath("~/Image/") + f.FileName);
                    }
                }
            }
            return RedirectToAction("Index", "ManageMobile");
        }
    }
}