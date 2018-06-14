using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Api
{
    public class NhaCungCapController : ApiController
    {
        public IHttpActionResult GetAllNhaCungCap()
        {
            IList<NhaCungCapViewModel> nhacc = null;
            using (var ctx = new QLBANHANGEntities())
            {
                nhacc = ctx.NHACCs.Select(s => new NhaCungCapViewModel()
                {
                    MACC = s.MACC,
                    TENCC = s.TENCC,
                    DIACHI = s.DIACHI,
                    SDT = s.SDT
                }).ToList<NhaCungCapViewModel>();
            }

            if (nhacc.Count == 0)
            {
                return NotFound();
            }

            return Ok(nhacc);
        }
    }
}
