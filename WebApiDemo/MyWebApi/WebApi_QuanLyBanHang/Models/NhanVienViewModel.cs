using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi_QuanLyBanHang.Models
{
    public class NhanVienViewModel
    {
        [Display(Name ="Mã Nhân Viên")]
        public int MANV { get; set; }

        [Display(Name ="Tên Nhân Viên")]
        public string HOTEN { get; set; }

        [Display(Name ="Ngày Sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage ="Ngày sinh là trường bắt buộc")]
        public DateTime? NGAYSINH { get; set; }

        [Display(Name ="Giới Tính")]
        [Required(ErrorMessage ="Giới tính là trường bắt buộc")]
        public string GT { get; set; }

        [Display(Name ="Điện Thoại")]
        public int? SDT { get; set; }

        [Display(Name ="Mail")]
        public string MAIL { get; set; }

        [Display(Name ="Địa Chỉ")]
        [Required(ErrorMessage ="Địa chỉ là trường bắt buộc")]
        public string DIACHI { get; set; }

        [Display(Name ="Ngày Làm")]
        [Required(ErrorMessage ="Ngày làm là trường bắt buộc")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NGAYLAM { get; set; }
    }
}