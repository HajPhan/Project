using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class LoaiSanPhamViewModel
    {
        [Display(Name ="Mã Loại")]
        public int MALOAI { get; set; }

        [Display(Name ="Tên Loại")]
        public string TENLOAI { get; set; }

        [Display(Name ="Đơn Vị Tính")]
        public string DVT { get; set; }
    }
}