using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using PagedList;
using PagedList.Mvc;
using WebApi_QuanLyBanHang.Models;

namespace WebApi_QuanLyBanHang.Controllers.Mvc
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            IEnumerable<NhaSanXuatViewModel> nhasxes = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53590/api/");

                //HTTP GET
                var respontTask = client.GetAsync("nhasanxuat");
                respontTask.Wait();

                var result = respontTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<NhaSanXuatViewModel>>();
                    readTask.Wait();

                    nhasxes = readTask.Result;
                }
                else
                {
                    //log respone  status here.
                    nhasxes = Enumerable.Empty<NhaSanXuatViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact adminstractor.");
                }
            }
                return View(nhasxes.ToPagedList(pageNumber,pageSize));
        }
    }
}