using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDAO
    {
        private DBContext db;
        public OrderDAO()
        {
            db = new DBContext();
        }

        public List<Order> GetAllOrder()
        {
            return db.Orders.ToList();
        }

        public List<Order> GetAllOrderOfUser(User user)
        {
            return db.Orders.Where(x => x.username == user.username).ToList();
        }

        public Order GetOrder(int orderID)
        {
            return db.Orders.SingleOrDefault(x => x.orderID == orderID);
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public int GetCurrentOrderID()
        {
            return db.Orders.Max(x => x.orderID);
        }
    }
}
