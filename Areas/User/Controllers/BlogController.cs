using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_ENGLISH.Areas.User.Controllers
{
    public class BlogController : Controller
    {
        // GET: User/Blog
        public ActionResult Index()
        {
            return View();
        }
    }
}