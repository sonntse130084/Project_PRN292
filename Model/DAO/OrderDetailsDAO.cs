using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class OrderDetailsDAO
    {
        private DBContext db;
        public OrderDetailsDAO()
        {
            db = new DBContext();
        }

        public List<OrderDetail> GetAllDetailsOfOrder(int orderID)
        {
            return db.OrderDetails.Where(x => x.orderID == orderID).ToList();
        }

        public void Add(OrderDetail details)
        {
            db.OrderDetails.Add(details);
            db.SaveChanges();
        }
    }
}
