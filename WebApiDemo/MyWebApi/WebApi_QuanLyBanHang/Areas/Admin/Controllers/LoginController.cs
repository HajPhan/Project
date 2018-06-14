using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_QuanLyBanHang.Areas.Admin.Models;
using WebApi_QuanLyBanHang.common;
using WebApi_QuanLyBanHang.Models;
using WebApi_QuanLyBanHang.Common;

namespace WebApi_QuanLyBanHang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginSystem(LoginModel model)
        {
            var check = new CheckLogin();
            if (ModelState.IsValid)
            {
                var result = check.Login(model.UserName, model.PassWord);

                if (result)
                {
                    var user = check.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.userId = user.ID;
                    userSession.password = user.Password;

                    Session.Add(CommonLogin.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Đăng nhập thất bại");
                }
            }

            return View("Index");
        }
    }
}