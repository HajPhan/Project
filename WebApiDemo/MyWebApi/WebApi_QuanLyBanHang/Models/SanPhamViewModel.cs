using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class SanPhamViewModel
    {
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public int? MASX { get; set; }
        public int? MALOAI { get; set; }
        public decimal? GIATHANH { get; set; }
    }
}