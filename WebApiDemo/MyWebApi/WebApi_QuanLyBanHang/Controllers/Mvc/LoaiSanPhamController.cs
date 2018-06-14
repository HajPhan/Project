using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using PagedList.Mvc;
using PagedList;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Mvc
{
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPham
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IEnumerable<LoaiSanPhamViewModel> loaisps = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/");

                // HTTP GET
                var respontTask = client.GetAsync("loaisanpham");
                respontTask.Wait();

                var result = respontTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<LoaiSanPhamViewModel>>();
                    readTask.Wait();

                    loaisps = readTask.Result;
                }
                else
                {
                    // log respont status here.
                    loaisps = Enumerable.Empty<LoaiSanPhamViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administactor.");
                }
            }

                return View(loaisps.ToPagedList(pageNumber,pageSize));
        }
    }
}