using System;
using System.Linq;
using System.Web.Mvc;
using Project2.Models;

public class don_hangController : Controller
{
    private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

    // Hiển thị danh sách đơn hàng
    public ActionResult Index()
    {
        var don_hang = db.don_hang.Include("nguoi_dung").ToList();
        return View(don_hang);
    }

    // Thanh toán đơn hàng
    public ActionResult ThanhToan(int id)
    {
        var donHang = db.don_hang.Find(id);
        if (donHang == null)
        {
            ViewBag.ErrorMessage = "Đơn hàng không tồn tại.";
            return View("Error");
        }

        // Tạo bản ghi thanh toán
        thanh_toan thanhToan = new thanh_toan
        {
            don_hang_id = donHang.don_hang_id,
            phuong_thuc = "Chuyển khoản qua Ngân hàng", // Phương thức mặc định
            so_tien = donHang.tong_tien,
            ngay_thanh_toan = DateTime.Now
        };

        db.thanh_toan.Add(thanhToan);
        db.SaveChanges();

        // Xóa chi tiết đơn hàng
        var chiTietDonHang = db.chi_tiet_don_hang.Where(c => c.don_hang_id == id).ToList();
        foreach (var chiTiet in chiTietDonHang)
        {
            db.chi_tiet_don_hang.Remove(chiTiet);
        }

        // Xóa đơn hàng
        db.don_hang.Remove(donHang);
        db.SaveChanges();

        // Điều hướng đến danh sách đơn hàng sau khi thanh toán
        return RedirectToAction("Index","thanh_toan");
    }

    // Xóa đơn hàng
    public ActionResult Delete(int id)
    {
        var donHang = db.don_hang.Find(id);
        if (donHang != null)
        {
            // Xóa các bản ghi thanh toán liên quan (nếu có)
            var thanhToan = db.thanh_toan.Where(t => t.don_hang_id == id).FirstOrDefault();
            if (thanhToan != null)
            {
                db.thanh_toan.Remove(thanhToan);
            }

            // Xóa các bản ghi chi tiết đơn hàng liên quan (nếu có)
            var chiTietDonHang = db.chi_tiet_don_hang.Where(c => c.don_hang_id == id).ToList();
            foreach (var chiTiet in chiTietDonHang)
            {
                db.chi_tiet_don_hang.Remove(chiTiet);
            }

            // Xóa đơn hàng
            db.don_hang.Remove(donHang);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
