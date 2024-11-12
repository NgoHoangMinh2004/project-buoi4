using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class nguoi_dung
    {
        public nguoi_dung()
        {
            this.don_hang = new HashSet<don_hang>();
        }

        [Display(Name = "Mã người dùng")]
        public int nguoi_dung_id { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string ten_dang_nhap { get; set; }

        [Display(Name = "Mật khẩu")]
        public string mat_khau { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Họ và tên")]
        public string ho_ten { get; set; }

        [Display(Name = "Địa chỉ")]
        public string dia_chi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string so_dien_thoai { get; set; }

        [Display(Name = "Ngày đăng ký")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ngay_dang_ky { get; set; }

        public virtual ICollection<don_hang> don_hang { get; set; }
    }
}
