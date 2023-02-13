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
    public class DapAnsController : Controller
    {
        private WEBEntities db = new WEBEntities();

        // GET: Admin/DapAns
        public ActionResult Index()
        {

            var dapAns = db.DapAns.Include(d => d.CauHoi);
            return View(dapAns.ToList());
        }

        // GET: Admin/DapAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            return View(dapAn);
        }

        // GET: Admin/DapAns/Create
        public ActionResult Create()
        {
            ViewBag.MaCauHoi = new SelectList(db.CauHois, "Id", "CauHoi1");
            return View();
        }

        // POST: Admin/DapAns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaCauHoi,Dap_an_A,Dap_an_B,Dap_an_C,Dap_an_D")] DapAn dapAn)
        {
            if (ModelState.IsValid)
            {
                db.DapAns.Add(dapAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCauHoi = new SelectList(db.CauHois, "Id", "CauHoi1", dapAn.MaCauHoi);
            return View(dapAn);
        }

        // GET: Admin/DapAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCauHoi = new SelectList(db.CauHois, "Id", "CauHoi1", dapAn.MaCauHoi);
            return View(dapAn);
        }

        // POST: Admin/DapAns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaCauHoi,Dap_an_A,Dap_an_B,Dap_an_C,Dap_an_D")] DapAn dapAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dapAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCauHoi = new SelectList(db.CauHois, "Id", "CauHoi1", dapAn.MaCauHoi);
            return View(dapAn);
        }

        // GET: Admin/DapAns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DapAn dapAn = db.DapAns.Find(id);
            if (dapAn == null)
            {
                return HttpNotFound();
            }
            return View(dapAn);
        }

        // POST: Admin/DapAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DapAn dapAn = db.DapAns.Find(id);
            db.DapAns.Remove(dapAn);
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
