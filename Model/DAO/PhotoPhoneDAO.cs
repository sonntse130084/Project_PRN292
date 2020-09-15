using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PhotoPhoneDAO
    {
        private DBContext db;
        public PhotoPhoneDAO()
        {
            db = new DBContext();
        }

        public List<PhotoPhone> GetPhotoOfPhone(string phoneID)
        {
            return db.PhotoPhones.Where(x => x.phoneID == phoneID).ToList();
        }
        public PhotoPhone GetPhoto(string urlPhoto)
        {
            return db.PhotoPhones.SingleOrDefault(x => x.urlPhoto == urlPhoto);
        }

        public bool Insert(PhotoPhone photo)
        {
            db.PhotoPhones.Add(photo);
            db.SaveChanges();
            return true;
        }

        public bool DeletePhotoOfPhone(string phoneID)
        {
            List<PhotoPhone> list = GetPhotoOfPhone(phoneID);
            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (PhotoPhone photo in list)
                {
                    db.PhotoPhones.Remove(photo);
                    db.SaveChanges();
                }
                return true;
            }
        }
    }
}
