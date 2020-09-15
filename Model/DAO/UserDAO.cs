using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class UserDAO
    {
        private DBContext db;
        public UserDAO()
        {
            db = new DBContext();
        }

        public bool Login(string username, string password)
        {
            int result = db.Users.Count(x => x.username == username && x.password == password && x.status == true);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public User GetUser(string username)
        {
            return db.Users.SingleOrDefault(x => x.username == username);
        }

        public List<User> GetAllCustomer()
        {
            List<User> list = (from User in db.Users where User.Role.roleName == "Customer" && User.status == true select User).ToList();
            return list;
        }

        public void Delete(string username)
        {
            User u = GetUser(username);
            u.status = false;
            db.SaveChanges();
        }
        public void Update(User user)
        {
            User u = GetUser(user.username);
            u.avatar = user.avatar;
            u.fullName = user.fullName;
            u.address = user.address;
            u.email = user.email;
            u.phone = user.phone;
            db.SaveChanges();
        }

        public void UpdatePassword(string newPWD, string username)
        {
            User u = GetUser(username);
            u.password = newPWD;
            db.SaveChanges();
        }

        public bool Insert(User user)
        {
            User u = GetUser(user.username);
            if (u != null)
            { 
                return false;
            }
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
    }
}
