using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project2.Models;

namespace prj2.Controllers
{
    public class san_phamController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: san_pham
        public ActionResult Index()
        {
            var san_pham = db.san_pham.ToList();
            return View(san_pham);
        }
        public ActionResult Details(int id)
        {
            // Tìm sản phẩm theo id
            var san_pham = db.san_pham.FirstOrDefault(s => s.san_pham_id == id);

            // Nếu không tìm thấy sản phẩm, trả về lỗi 404
            if (san_pham == null)
            {
                return HttpNotFound();
            }

            // Trả về view với dữ liệu của sản phẩm
            return View(san_pham);
        }
        // Đặt hàng sản phẩm
        public ActionResult Order(int id)
        {
            var san_pham = db.san_pham.Find(id);
            if (san_pham == null)
            {
                return HttpNotFound();
            }

            // Tạo đơn hàng mới cho sản phẩm
            var don_hang = new don_hang
            {
                ngay_dat = DateTime.Now,
                tong_tien = san_pham.gia,
                nguoi_dung_id = 1 // Giả sử người dùng có id là 1
            };

            db.don_hang.Add(don_hang);
            db.SaveChanges();

            return RedirectToAction("Index", "don_hang");
        }
    }
}
