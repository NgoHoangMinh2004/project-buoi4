using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project2.Models;

namespace prj2.Controllers
{
    public class chi_tiet_don_hangController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: chi_tiet_don_hang
        public ActionResult Index()
        {
            var chi_tiet_don_hang = db.chi_tiet_don_hang.Include(c => c.don_hang);
            return View(chi_tiet_don_hang.ToList());
        }

        // GET: chi_tiet_don_hang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_don_hang chi_tiet_don_hang = db.chi_tiet_don_hang.Find(id);
            if (chi_tiet_don_hang == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiet_don_hang);
        }

        // GET: chi_tiet_don_hang/Create
        public ActionResult Create()
        {
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id");
            return View();
        }

        // POST: chi_tiet_don_hang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "chi_tiet_don_hang_id,don_hang_id,so_luong,gia")] chi_tiet_don_hang chi_tiet_don_hang)
        {
            if (ModelState.IsValid)
            {
                db.chi_tiet_don_hang.Add(chi_tiet_don_hang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", chi_tiet_don_hang.don_hang_id);
            return View(chi_tiet_don_hang);
        }

        // GET: chi_tiet_don_hang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_don_hang chi_tiet_don_hang = db.chi_tiet_don_hang.Find(id);
            if (chi_tiet_don_hang == null)
            {
                return HttpNotFound();
            }
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", chi_tiet_don_hang.don_hang_id);
            return View(chi_tiet_don_hang);
        }

        // POST: chi_tiet_don_hang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "chi_tiet_don_hang_id,don_hang_id,so_luong,gia")] chi_tiet_don_hang chi_tiet_don_hang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chi_tiet_don_hang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", chi_tiet_don_hang.don_hang_id);
            return View(chi_tiet_don_hang);
        }

        // GET: chi_tiet_don_hang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chi_tiet_don_hang chi_tiet_don_hang = db.chi_tiet_don_hang.Find(id);
            if (chi_tiet_don_hang == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiet_don_hang);
        }

        // POST: chi_tiet_don_hang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chi_tiet_don_hang chi_tiet_don_hang = db.chi_tiet_don_hang.Find(id);
            db.chi_tiet_don_hang.Remove(chi_tiet_don_hang);
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
