using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class don_hang
    {
        public don_hang()
        {
            this.chi_tiet_don_hang = new HashSet<chi_tiet_don_hang>();
            this.thanh_toan = new HashSet<thanh_toan>();
        }

        [Display(Name = "Mã đơn hàng")]
        public int don_hang_id { get; set; }

        [Display(Name = "Mã người dùng")]
        public Nullable<int> nguoi_dung_id { get; set; }

        [Display(Name = "Ngày đặt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ngay_dat { get; set; }

        [Display(Name = "Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ", ApplyFormatInEditMode = true)]
        public decimal tong_tien { get; set; }

        public virtual ICollection<chi_tiet_don_hang> chi_tiet_don_hang { get; set; }
        public virtual nguoi_dung nguoi_dung { get; set; }
        public virtual ICollection<thanh_toan> thanh_toan { get; set; }
    }
}
