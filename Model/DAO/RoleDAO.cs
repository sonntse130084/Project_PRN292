using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.DAO
{
    public class RoleDAO
    {
        private DBContext db;
        public RoleDAO()
        {
            db = new DBContext();
        }

        public List<SelectListItem> RoleList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            List<Role> roles = db.Roles.ToList();
            foreach(Role r in roles)
            {
                list.Add(new SelectListItem() {
                        Text = r.roleName,
                        Value = r.roleID
                    }
                );
            }
            return list;
        }
    }
}
