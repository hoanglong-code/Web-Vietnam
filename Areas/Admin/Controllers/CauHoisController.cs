using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB_ENGLISH.Models;

namespace WEB_ENGLISH.Areas.Admin.Controllers
{
    public class CauHoisController : Controller
    {
        private WEBEntities db = new WEBEntities();

        // GET: Admin/CauHois
        public ActionResult Index()
        {
            var cauHois = db.CauHois.Include(c => c.DeThi);
            return View(cauHois.ToList());
        }

        // GET: Admin/CauHois/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Create
        public ActionResult Create()
        {
            ViewBag.MaDeThi = new SelectList(db.DeThis, "Id", "ThoiGianThi");
            return View();
        }

        // POST: Admin/CauHois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaDeThi,CauHoi1,Dap_an_a,Dap_an_b,Dap_an_c,Dap_an_d,GhiChu")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                db.CauHois.Add(cauHoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDeThi = new SelectList(db.DeThis, "Id", "ThoiGianThi", cauHoi.MaDeThi);
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "Id", "ThoiGianThi", cauHoi.MaDeThi);
            return View(cauHoi);
        }

        // POST: Admin/CauHois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaDeThi,CauHoi1,Dap_an_a,Dap_an_b,Dap_an_c,Dap_an_d,GhiChu")] CauHoi cauHoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cauHoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDeThi = new SelectList(db.DeThis, "Id", "ThoiGianThi", cauHoi.MaDeThi);
            return View(cauHoi);
        }

        // GET: Admin/CauHois/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CauHoi cauHoi = db.CauHois.Find(id);
            if (cauHoi == null)
            {
                return HttpNotFound();
            }
            return View(cauHoi);
        }

        // POST: Admin/CauHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CauHoi cauHoi = db.CauHois.Find(id);
            db.CauHois.Remove(cauHoi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
