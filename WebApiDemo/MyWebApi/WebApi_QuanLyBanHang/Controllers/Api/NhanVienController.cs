using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using WebApi_QuanLyBanHang.Models;


namespace WebApi_QuanLyBanHang.Controllers.Api
{
    public class NhanVienController : ApiController
    {

        public IHttpActionResult GetAllNhanVien()
        {
            IList<NhanVienViewModel> nhanvien = null;
            using (var ctx = new QLBANHANGEntities())
            {
                nhanvien = ctx.NHANVIENs.Select(s => new NhanVienViewModel()
                {
                    MANV = s.MANV,
                    HOTEN = s.HOTEN,
                    NGAYSINH = s.NGAYSINH,
                    GT = s.GT,
                    SDT = s.SDT,
                    MAIL = s.MAIL,
                    DIACHI = s.DIACHI,
                    NGAYLAM = s.NGAYLAM
                }).ToList<NhanVienViewModel>();

            }

            if (nhanvien.Count == 0)
            {
                return NotFound();
            }
            return Ok(nhanvien);

        }

        public IHttpActionResult PostNewNhanVien(NhanVienViewModel nhanvien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invaild data");
            }

            using (var ctx = new QLBANHANGEntities())
            {
                //ctx.NHANVIENs.Add(new NHANVIEN()
                //{
                //    MANV = nhanvien.MANV,
                //    HOTEN = nhanvien.HOTEN,
                //    NGAYSINH = nhanvien.NGAYSINH,
                //    GT = nhanvien.GT,
                //    SDT = nhanvien.SDT,
                //    MAIL = nhanvien.MAIL,

                //}
                ctx.sp_Insert_NhanVien(nhanvien.HOTEN, nhanvien.NGAYSINH, nhanvien.GT, nhanvien.SDT, nhanvien.MAIL, nhanvien.DIACHI, nhanvien.NGAYSINH);
                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}
