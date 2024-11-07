using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using prj2.Models;
using System.Security.Cryptography;
using System.Text;

namespace prj2.Controllers
{
    public class nguoi_dungController : Controller
    {
        private prj2_2210900044_nhmEntities db = new prj2_2210900044_nhmEntities();

        // GET: nguoi_dung/SignUp
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: nguoi_dung/SignUp
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "nguoi_dung_id,ten_dang_nhap,mat_khau,email,ho_ten,dia_chi,so_dien_thoai,ngay_dang_ky")] nguoi_dung nguoi_dung)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem tên đăng nhập có bị trùng không
                var existingUser = db.nguoi_dung.FirstOrDefault(u => u.ten_dang_nhap == nguoi_dung.ten_dang_nhap);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.";
                    return View(nguoi_dung);
                }

                // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                nguoi_dung.mat_khau = HashPassword(nguoi_dung.mat_khau);

                // Thêm người dùng vào cơ sở dữ liệu
                db.nguoi_dung.Add(nguoi_dung);
                db.SaveChanges();

                // Thông báo thành công
                TempData["SuccessMessage"] = "Tạo tài khoản thành công! Bạn có thể đăng nhập ngay bây giờ.";
                return RedirectToAction("Login");
            }

            return View(nguoi_dung);
        }

        // GET: nguoi_dung/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: nguoi_dung/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string ten_dang_nhap, string mat_khau)
        {
            var user = db.nguoi_dung.FirstOrDefault(u => u.ten_dang_nhap == ten_dang_nhap);
            if (user != null && user.mat_khau == HashPassword(mat_khau))
            {
                // Nếu đăng nhập thành công
                Session["User"] = user;
                return RedirectToAction("Index", "Home");  // Chuyển hướng đến trang chủ hoặc trang phù hợp khác
            }

            // Nếu đăng nhập không thành công
            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }

        // Hàm mã hóa mật khẩu
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashBytes);
            }
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
