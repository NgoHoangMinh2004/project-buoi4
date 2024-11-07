using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prj2.Models;

namespace prj2.Controllers
{
    public class danh_muc_san_phamController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: danh_muc_san_pham
        public ActionResult Index()
        {
            return View(db.danh_muc_san_pham.ToList());
        }

        // GET: danh_muc_san_pham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_san_pham danh_muc_san_pham = db.danh_muc_san_pham.Find(id);
            if (danh_muc_san_pham == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_san_pham);
        }

        // GET: danh_muc_san_pham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: danh_muc_san_pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "danh_muc_id,ten_danh_muc")] danh_muc_san_pham danh_muc_san_pham)
        {
            if (ModelState.IsValid)
            {
                db.danh_muc_san_pham.Add(danh_muc_san_pham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(danh_muc_san_pham);
        }

        // GET: danh_muc_san_pham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_san_pham danh_muc_san_pham = db.danh_muc_san_pham.Find(id);
            if (danh_muc_san_pham == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_san_pham);
        }

        // POST: danh_muc_san_pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "danh_muc_id,ten_danh_muc")] danh_muc_san_pham danh_muc_san_pham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danh_muc_san_pham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danh_muc_san_pham);
        }

        // GET: danh_muc_san_pham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            danh_muc_san_pham danh_muc_san_pham = db.danh_muc_san_pham.Find(id);
            if (danh_muc_san_pham == null)
            {
                return HttpNotFound();
            }
            return View(danh_muc_san_pham);
        }

        // POST: danh_muc_san_pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            danh_muc_san_pham danh_muc_san_pham = db.danh_muc_san_pham.Find(id);
            db.danh_muc_san_pham.Remove(danh_muc_san_pham);
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
