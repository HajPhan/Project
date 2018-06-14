using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Common
{
    public class UserLogin
    {
        public int userId { get; set; }
        public int? password { get; set; }
    }
}