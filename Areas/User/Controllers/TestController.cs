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
    public class TestController : Controller
    {
        Models.WEBEntities db = new Models.WEBEntities();
        // GET: User/Trangchu

        public ActionResult Index(int MADETHI)
        {
            List<CauHoi> lst = db.CauHois.Where(x => x.MaDeThi == MADETHI).ToList();
            return View(lst);
        }
        [HttpPost]
        public ActionResult Check(int id)
        {
            String QA = Request["QA"];
            JObject json = JObject.Parse(QA);
            foreach (var e in json)
            {
                List<DapAn> lst = db.DapAns.Where((x => (x.CauHoi.Id == id))).ToList();
                foreach (var i in lst)
                {
                    int idCH = Int32.Parse(e.Key.ToString());
                    String CauTL = e.Value.ToString();
                    ViewBag.QA = CauTL;
                }
            }
                return View();
        }
    }
}