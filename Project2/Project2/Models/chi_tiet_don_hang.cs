using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class chi_tiet_don_hang
    {
        [Display(Name = "Mã chi tiết đơn hàng")]
        public int chi_tiet_don_hang_id { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public Nullable<int> don_hang_id { get; set; }

        [Display(Name = "Số lượng")]
        public int so_luong { get; set; }

        [Display(Name = "Giá")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ", ApplyFormatInEditMode = true)]
        public decimal gia { get; set; }

        public virtual don_hang don_hang { get; set; }
    }
}
