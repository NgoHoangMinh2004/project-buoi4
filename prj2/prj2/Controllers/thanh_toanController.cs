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
    public class thanh_toanController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: thanh_toan
        public ActionResult Index()
        {
            var thanh_toan = db.thanh_toan.Include(t => t.don_hang);
            return View(thanh_toan.ToList());
        }

        // GET: thanh_toan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            return View(thanh_toan);
        }

        // GET: thanh_toan/Create
        public ActionResult Create()
        {
            // Liên kết danh sách đơn hàng cho dropdown
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id");
            return View();
        }

        // POST: thanh_toan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "thanh_toan_id,don_hang_id,phuong_thuc,trang_thai,so_tien,ngay_thanh_toan")] thanh_toan thanh_toan)
        {
            if (ModelState.IsValid)
            {
                db.thanh_toan.Add(thanh_toan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Nếu có lỗi, gửi lại danh sách đơn hàng cho dropdown
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", thanh_toan.don_hang_id);
            return View(thanh_toan);
        }

        // GET: thanh_toan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", thanh_toan.don_hang_id);
            return View(thanh_toan);
        }

        // POST: thanh_toan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "thanh_toan_id,don_hang_id,phuong_thuc,trang_thai,so_tien,ngay_thanh_toan")] thanh_toan thanh_toan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanh_toan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.don_hang_id = new SelectList(db.don_hang, "don_hang_id", "don_hang_id", thanh_toan.don_hang_id);
            return View(thanh_toan);
        }

        // GET: thanh_toan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            if (thanh_toan == null)
            {
                return HttpNotFound();
            }
            return View(thanh_toan);
        }

        // POST: thanh_toan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thanh_toan thanh_toan = db.thanh_toan.Find(id);
            db.thanh_toan.Remove(thanh_toan);
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
