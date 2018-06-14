using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Net.Http;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Mvc
{
    public class NhaCungCapController : Controller
    {
        // GET: NhaCungCap
        public ActionResult Index(int? page)
        {
            IEnumerable<NhaCungCapViewModel> nhaccs = null;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/");

                //HTTP GET
                var respontTask = client.GetAsync("nhacungcap");
                respontTask.Wait();

                var result = respontTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList < NhaCungCapViewModel >> ();
                    readTask.Wait();

                    nhaccs = readTask.Result;
                }
                else
                {
                    // log respone status here.
                    nhaccs = Enumerable.Empty<NhaCungCapViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administractor.");
                }
            }
            return View(nhaccs.ToPagedList(pageNumber, pageSize));
        }
    }
}