using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class san_pham
    {
        [Display(Name = "Mã sản phẩm")]
        public int san_pham_id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ten_san_pham { get; set; }

        [Display(Name = "Giá")]
        [DisplayFormat(DataFormatString = "{0:N0} VNĐ", ApplyFormatInEditMode = true)]
        public decimal gia { get; set; }

        [Display(Name = "Mô tả")]
        public string mo_ta { get; set; }

        [Display(Name = "Danh mục ID")]
        public Nullable<int> danh_muc_id { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public string anh_san_pham { get; set; }

        public virtual danh_muc_san_pham danh_muc_san_pham { get; set; }
    }
}
