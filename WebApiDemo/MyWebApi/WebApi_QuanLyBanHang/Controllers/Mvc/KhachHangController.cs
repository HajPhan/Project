using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_QuanLyBanHang.Models;
using System.Net.Http;
using PagedList;
using PagedList.Mvc;

namespace WebApi_QuanLyBanHang.Controllers.Mvc
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult Index(int? page)
        {
            IEnumerable<KhachHangViewModel> khachhangs = null;
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/");

                // HTTP GET
                var respontTask = client.GetAsync("khachhang");
                respontTask.Wait();

                var result = respontTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<KhachHangViewModel>>();
                    readTask.Wait();

                    khachhangs = readTask.Result;
                }
                else
                {
                    // log respone status here.
                    khachhangs = Enumerable.Empty<KhachHangViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administractor.");
                }
            }
            return View(khachhangs.ToPagedList(pageNumber,pageSize));
        }
    }
}