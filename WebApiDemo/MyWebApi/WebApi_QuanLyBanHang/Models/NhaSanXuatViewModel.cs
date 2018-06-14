using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class NhaSanXuatViewModel
    {
        [Display(Name ="Mã Sản Xuất")]
        public int MASX { get; set; }

        [Display(Name ="Tên Sản Xuất")]
        public string TENSX { get; set; }

        [Display(Name ="Quốc Gia")]
        public string QUOCGIA { get; set; }
    }
}