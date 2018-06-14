using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Api
{
    public class KhachHangController : ApiController
    {

        public IHttpActionResult GetAllKhachHang()
        {
            IList<KhachHangViewModel> khachhang = null;

            using (var ctx = new QLBANHANGEntities())
            {
                khachhang = ctx.KHACHHANGs.Select(s => new KhachHangViewModel()
                {
                    MAKH = s.MAKH,
                    TENKH = s.TENKH,
                    NGAYSINH = s.NGAYSINH,
                    GT = s.GT,
                    SDT = s.SDT,
                    MAIL = s.MAIL,
                    DIACHI = s.DIACHI,
                    NGAYDK = s.NGAYDK
                }).ToList<KhachHangViewModel>();
            }

            if (khachhang.Count == 0)
            {
                return NotFound();
            }

            return Ok(khachhang);
        }
    }
}
