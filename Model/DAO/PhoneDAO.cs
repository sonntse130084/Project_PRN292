using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhoneDAO
    {
        private DBContext db;
        public PhoneDAO()
        {
            db = new DBContext();
        }

        public List<Phone> GetAllPhone()
        {
            return db.Phones.Where(x => x.status == true).ToList();
        }
        public Phone GetPhone(string phoneID)
        {
            return db.Phones.SingleOrDefault(x => x.phoneID == phoneID);
        }

        public bool Insert(Phone phone)
        {
            Phone p = GetPhone(phone.phoneID);
            if (p != null)
            {
                return false;
            }
            db.Phones.Add(phone);
            db.SaveChanges();
            return true;
        }

        public void Update(Phone phone)
        {
            Phone p = GetPhone(phone.phoneID);
            p.phoneName = phone.phoneName;
            p.description = phone.description;
            p.price = phone.price;
            p.quantity = phone.quantity;
            p.discount = phone.discount;
            p.supID = phone.supID;
            p.discount = phone.discount;
            db.SaveChanges();
        }

        public void Delete(string phoneID)
        {
            Phone p = GetPhone(phoneID);
            if (p != null)
            {
                p.status = false;
                db.SaveChanges();
            }
            db.SaveChanges();
        }

        public List<Phone> GetLastestPhone()
        {
            List<Phone> list = (from Phone in db.Phones where Phone.quantity > 0 && Phone.status == true orderby Phone.insertDate descending select Phone).ToList();
            return list;
        }

        public List<Phone> GetAllCurrentPhone()
        {
            List<Phone> list = (from Phone in db.Phones where Phone.quantity > 0 select Phone).ToList();
            return list;
        }

        public List<Phone> GetAllCurrentPhoneBySup(string supID)
        {
            List<Phone> list = (from Phone in db.Phones where Phone.quantity > 0 && Phone.supID == supID select Phone).ToList();
            return list;
        }


        public void UpdateQuantity(int quantity, string phoneID)
        {
            Phone p = GetPhone(phoneID);
            if (quantity <= p.quantity)
            {
                p.quantity -= quantity;
            }
            db.SaveChanges();
        }
    }
}
