using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_ENGLISH.Models;
using System.Data;
using System.Data.Entity;

namespace WEB_ENGLISH.Areas.User.Controllers
{
    public class MainController : Controller
    {
        WEBEntities db = new WEBEntities();
        // GET: User/Main
        public ActionResult Index()
        {
            List<WEB_ENGLISH.Models.product> lst = db.products.ToList();

            return View(lst);
        }
        public ActionResult items()
        {
            List<WEB_ENGLISH.Models.product> lst = db.products.ToList();
            return PartialView();
        }
    }
}