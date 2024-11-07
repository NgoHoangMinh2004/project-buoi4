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
    public class san_phamController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: san_pham
        public ActionResult Index()
        {
            var san_pham = db.san_pham.Include(s => s.danh_muc_san_pham); // Lấy dữ liệu sản phẩm cùng danh mục
            return View(san_pham.ToList());
        }

        // GET: san_pham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            san_pham san_pham = db.san_pham.Find(id); // Tìm sản phẩm theo ID
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            return View(san_pham); // Hiển thị thông tin chi tiết sản phẩm
        }

        // GET: san_pham/Create
        public ActionResult Create()
        {
            ViewBag.danh_muc_id = new SelectList(db.danh_muc_san_pham, "danh_muc_id", "ten_danh_muc"); // Chọn danh mục sản phẩm
            return View();
        }

        // POST: san_pham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ten_san_pham, gia, mo_ta, danh_muc_id")] san_pham san_pham)
        {
            if (ModelState.IsValid)
            {
                db.san_pham.Add(san_pham); // Thêm sản phẩm mới vào cơ sở dữ liệu
                db.SaveChanges();
                return RedirectToAction("Index"); // Quay lại danh sách sản phẩm
            }
            ViewBag.danh_muc_id = new SelectList(db.danh_muc_san_pham, "danh_muc_id", "ten_danh_muc", san_pham.danh_muc_id);
            return View(san_pham);
        }

        // GET: san_pham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            san_pham san_pham = db.san_pham.Find(id); // Tìm sản phẩm theo ID
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            ViewBag.danh_muc_id = new SelectList(db.danh_muc_san_pham, "danh_muc_id", "ten_danh_muc", san_pham.danh_muc_id); // Hiển thị danh mục
            return View(san_pham);
        }

        // POST: san_pham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "san_pham_id, ten_san_pham, gia, mo_ta, danh_muc_id")] san_pham san_pham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(san_pham).State = EntityState.Modified; // Cập nhật thông tin sản phẩm
                db.SaveChanges();
                return RedirectToAction("Index"); // Quay lại danh sách sản phẩm
            }
            ViewBag.danh_muc_id = new SelectList(db.danh_muc_san_pham, "danh_muc_id", "ten_danh_muc", san_pham.danh_muc_id);
            return View(san_pham);
        }

        // GET: san_pham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            san_pham san_pham = db.san_pham.Find(id); // Tìm sản phẩm theo ID
            if (san_pham == null)
            {
                return HttpNotFound();
            }
            return View(san_pham);
        }

        // POST: san_pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            san_pham san_pham = db.san_pham.Find(id); // Tìm sản phẩm theo ID
            db.san_pham.Remove(san_pham); // Xóa sản phẩm
            db.SaveChanges();
            return RedirectToAction("Index"); // Quay lại danh sách sản phẩm
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose(); // Giải phóng tài nguyên
            }
            base.Dispose(disposing);
        }
    }
}
