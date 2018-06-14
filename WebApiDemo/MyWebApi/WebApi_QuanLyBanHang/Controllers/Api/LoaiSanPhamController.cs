using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Api
{
    public class LoaiSanPhamController : ApiController
    {
        public IHttpActionResult GetAllLoaiSanPham()
        {
            IList<LoaiSanPhamViewModel> loaisp = null;
            using (var ctx = new QLBANHANGEntities())
            {
                loaisp = ctx.LOAISPs.Select(s => new LoaiSanPhamViewModel()
                {
                    MALOAI = s.MALOAI,
                    TENLOAI = s.TENLOAI,
                    DVT = s.DVT
                }).ToList<LoaiSanPhamViewModel>();
            }

            if (loaisp.Count == 0)
            {
                return NotFound();
            }

            return Ok(loaisp);
        }
    }
}
