using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class NhaCungCapViewModel
    {
        [Display(Name ="Mã Cung Cấp")]
        public int MACC { get; set; }

        [Display(Name ="Tên Nhà Cung Cấp")]
        public string TENCC { get; set; }

        [Display(Name ="Địa Chỉ")]
        public string DIACHI { get; set; }

        [Display(Name ="Điện Thoại")]
        public int? SDT { get; set; }
    }
}