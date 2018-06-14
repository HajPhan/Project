using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập username")]
        public int UserName { get; set; }

        [Required(ErrorMessage ="Mời nhập password")]
        public int PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}