using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using WEB_ENGLISH.Models;

namespace WEB_ENGLISH.Areas.User.Controllers
{
    public class DiemThiController : Controller
    {
        // GET: User/DiemThi
        Models.WEBEntities db = new Models.WEBEntities();
        public ActionResult TenND()
        {
            int idnd1 = Int32.Parse("" + Session["UserName"]);
            List<ThanhVien> lst = db.ThanhViens.Where(x => (x.Id == idnd1)).ToList();
            String hoten = lst.First().Username.ToString();
            ViewBag.ht = hoten;
            return View();
        }
        public int xuly(int id)
        {
            int socau = 0;
            List<CauHoi> lst = db.CauHois.Where(x => (x.Id == id)).ToList();
            socau = lst.Count();
            return socau;
        }
        public ActionResult Index(int id)
        {
            bool co = false;
            ViewBag.socau = 0;
            List<DapAn> lst = db.DapAns.Where((x => (x.CauHoi.Id == id))).ToList();
            
            foreach (var i in lst)
            {
                if (co = i.Dap_an_A == "true")
                {
                    ViewBag.socau++;
                    if (co = i.Dap_an_B == "true")
                    {
                        ViewBag.socau++;
                        if (co = i.Dap_an_C == "true")
                        {
                            ViewBag.socau++;
                            if (co = i.Dap_an_D == "true")
                            {
                                ViewBag.socau++;
                            }
                        }
                    }          
                }
                
            }
            ViewBag.socau = xuly(id);
            db.SaveChanges();
            return View();
        }
        
    }
}