using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Api
{
    public class NhaSanXuatController : ApiController
    {
        public IHttpActionResult GetAllNhaSanXuat()
        {
            IList<NhaSanXuatViewModel> nhasx = null;
            using (var ctx = new QLBANHANGEntities())
            {
                nhasx = ctx.NHASXes.Select(s => new NhaSanXuatViewModel()
                {
                    MASX = s.MASX,
                    TENSX = s.TENSX,
                    QUOCGIA = s.QUOCGIA
                }).ToList<NhaSanXuatViewModel>();
            }

            if (nhasx.Count == 0)
            {
                return NotFound();
            }

            return Ok(nhasx);
        }
    }
}
