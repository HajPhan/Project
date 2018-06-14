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
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index(int? page)
        {
            IEnumerable<NhanVienViewModel> nhanviens = null;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/");

                // HTTP GET
                var respontTask = client.GetAsync("nhanvien");
                respontTask.Wait();

                var result = respontTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<NhanVienViewModel>>();
                    readTask.Wait();

                    nhanviens = readTask.Result;
                }
                else
                {
                    // log respone status here.
                    nhanviens = Enumerable.Empty<NhanVienViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administractor.");
                }
            }
            return View(nhanviens.ToPagedList(pageNumber,pageSize));
        }

        // POST: Nhan Vien
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(NhanVienViewModel nhanvien)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/nhanvien");

                // HTTP POST
                var postTask = client.PostAsJsonAsync<NhanVienViewModel>("nhanvien", nhanvien);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact addministractor.");

            return View(nhanvien);

        }

    }
}