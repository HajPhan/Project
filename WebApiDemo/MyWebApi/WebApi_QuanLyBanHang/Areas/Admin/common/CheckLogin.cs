using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi_QuanLyBanHang.Areas.Admin.Models;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.common
{
    public class CheckLogin
    {
        QLBANHANGEntities db = new QLBANHANGEntities();
        public bool Login(int id, int password)
        {
            var result = db.TAIKHOANs.Count(x => x.ID == id && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public TAIKHOAN GetById(int userId)
        {
            return db.TAIKHOANs.Find(userId);
        }
    }
}