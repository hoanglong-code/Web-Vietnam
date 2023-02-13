using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using WEB_ENGLISH.Models;
using System.Text;

namespace WEB_ENGLISH.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        WEBEntities db = new WEBEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Data.DTO.Class2 user)
        {
            if (ModelState.IsValid)
            {
                int isVal = Data.DAO.Class1.CheckLogin(user.UserName, user.Passwords);

                if (isVal == 1)
                {
                    string ReturnUrl = "";
                    Session["UserName"] = user.UserName;
                    List<Models.admin> num = db.admins.Where(x => x.Username == user.UserName).ToList();
                    int id = 0;
                    string img = "";
                    foreach (var item in num)
                    {
                        id = item.Id;
                        img = item.Anh;
                    }
                    ViewBag.id = num;
                    Session["id"] = id;
                    FormsAuthentication.SetAuthCookie(user.Passwords, false);
                    if (Request.QueryString["ReturnUrl"] == null)
                        ReturnUrl = "~/Admin/Home/Index";
                    else ReturnUrl = Request.QueryString["ReturnUrl"].ToString();
                    return Redirect(ReturnUrl);
                }
                else
                {
                    // error
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }
            }
            return View(user);
        }
        public ActionResult Logout()
        {
            // Hủy session đã lưu dưới Client
            Session.Remove("id");
            Session.Remove("userName");
            return Redirect("~/Admin/Home/Index");
        }
        public ActionResult SignUp()
        {
            return View();
        }
    }
}