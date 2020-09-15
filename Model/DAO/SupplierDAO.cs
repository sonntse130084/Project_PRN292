using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class SupplierDAO
    {
        private DBContext db;
        public SupplierDAO()
        {
            db = new DBContext();
        }

        public List<Supplier> GetAllSupplier()
        {
            return db.Suppliers.ToList();
        }

        public Supplier GetSupplier(string supID)
        {
            return db.Suppliers.SingleOrDefault(x => x.supID == supID);
        }
    }
}
