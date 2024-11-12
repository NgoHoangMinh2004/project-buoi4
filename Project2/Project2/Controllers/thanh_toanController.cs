
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

public class thanh_toanController : Controller
{
    private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

    // Hiển thị form thanh toán chuyển khoản


    public ActionResult ThanhToanChuyenKhoan()
    {
        // Các thông tin tĩnh mà bạn muốn hiển thị
        ViewBag.Message = "Chọn phương thức thanh toán: Chuyển khoản qua MoMo hoặc tài khoản ngân hàng.";
        ViewBag.MoMoInfo = "Chuyển khoản qua MoMo: 0878255194";
        ViewBag.BankInfo = "Chuyển khoản qua ngân hàng: Ngân hàng BIDV, Số tài khoản: 8812816999";

        return View();
    }
    public ActionResult Index()
    {
        var thanhToans = db.thanh_toan.ToList(); // Lấy danh sách thanh toán từ cơ sở dữ liệu

        foreach (var item in thanhToans)
        {
            // Kiểm tra nếu don_hang_id là null hoặc 0, gán mặc định là 1
            if (item.don_hang_id == 0 || item.don_hang_id == null)
            {
                item.don_hang_id = 1;  // Gán mặc định là 1 nếu không có don_hang_id
            }
        }

        return View(thanhToans);
    }


    // Xác nhận và hiển thị form xóa thanh toán
    public ActionResult Delete(int id)
    {
        var thanhToan = db.thanh_toan.Find(id);
        if (thanhToan == null)
        {
            ViewBag.ErrorMessage = "Thanh toán không tồn tại.";
            return View("Error");
        }
        return View(thanhToan);
    }

    // Phương thức POST để thực sự xóa thanh toán
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var thanhToan = db.thanh_toan.Find(id);
        if (thanhToan == null)
        {
            ViewBag.ErrorMessage = "Thanh toán không tồn tại.";
            return View("Error");
        }

        // Xóa thanh toán
        db.thanh_toan.Remove(thanhToan);
        db.SaveChanges();

        // Sau khi xóa thành công, quay lại trang danh sách thanh toán
        return RedirectToAction("Index");
    }

    // Hiển thị form thanh toán cho một đơn hàng
    public ActionResult Create(int donHangId)
    {
        var donHang = db.don_hang.Find(donHangId);
        if (donHang == null)
        {
            ViewBag.ErrorMessage = "Đơn hàng không tồn tại.";
            return View("Error");
        }

        // Truyền thông tin đơn hàng vào view
        ViewBag.ten_khach_hang = donHang.nguoi_dung.ten_dang_nhap;
        ViewBag.PhieuThanhToanOptions = new SelectList(new List<string> { "Chuyển khoản qua Momo", "Chuyển khoản qua Ngân hàng" });

        // Khởi tạo đối tượng thanh_toan và gán giá trị mặc định cho ngày thanh toán
        var thanhToan = new thanh_toan
        {
            don_hang_id = donHang.don_hang_id,
            so_tien = donHang.tong_tien,
            ngay_thanh_toan = DateTime.Now // Gán ngày thanh toán là ngày hiện tại
        };

        return View(thanhToan);
    }

    // Xử lý thanh toán và lưu vào cơ sở dữ liệu
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(thanh_toan thanhToan)
    {
        if (ModelState.IsValid)
        {
            var donHang = db.don_hang.Find(thanhToan.don_hang_id);
            if (donHang == null)
            {
                ViewBag.ErrorMessage = "Đơn hàng không tồn tại.";
                return View("Error");
            }

            // Lưu thanh toán vào cơ sở dữ liệu
            thanhToan.ngay_thanh_toan = DateTime.Now; // Đảm bảo ngày thanh toán là ngày hiện tại khi submit form
            db.thanh_toan.Add(thanhToan);
            db.SaveChanges();

            // Sau khi thanh toán xong, quay lại danh sách đơn hàng 
            return RedirectToAction("Index", "don_hang");
        }
        else
        {
            ViewBag.ErrorMessage = "Thông tin thanh toán không hợp lệ.";
            return View(thanhToan);
        }
    }
}
