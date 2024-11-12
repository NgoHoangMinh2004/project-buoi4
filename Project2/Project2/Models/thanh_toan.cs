using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class thanh_toan
    {
        [Display(Name = "Mã thanh toán")]
        public int thanh_toan_id { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public Nullable<int> don_hang_id { get; set; }

        [Display(Name = "Phương thức thanh toán")]
        public string phuong_thuc { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public string trang_thai { get; set; }

        [Display(Name = "Số tiền thanh toán")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ", ApplyFormatInEditMode = true)]
        public Nullable<decimal> so_tien { get; set; }

        [Display(Name = "Ngày thanh toán")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ngay_thanh_toan { get; set; }

        public virtual don_hang don_hang { get; set; }
    }
}
