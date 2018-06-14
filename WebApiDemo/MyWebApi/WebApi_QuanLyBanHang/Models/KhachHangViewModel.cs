using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class KhachHangViewModel
    {
        [Display(Name ="Mã Khách Hàng")]
        public int MAKH { get; set; }

        [Display(Name ="Tên Khách Hàng")]
        public string TENKH { get; set; }

        [Display(Name ="Ngày Sinh")]
        [Required(ErrorMessage ="Ngày sinh là trường bắt buộc")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? NGAYSINH { get; set; }

        [Display(Name ="Giới Tính")]
        public string GT { get; set; }

        [Display(Name ="Điện Thoại")]
        public int? SDT { get; set; }

        [Display(Name ="Mail")]
        public string MAIL { get; set; }

        [Display(Name ="Địa Chỉ")]
        public string DIACHI { get; set; }

        [Display(Name ="Ngày Đăng Ký")]
        [Required(ErrorMessage = "Ngày sinh là trường bắt buộc")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NGAYDK { get; set; }
    }
}