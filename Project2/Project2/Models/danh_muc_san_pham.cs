using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2.Models
{
    public partial class danh_muc_san_pham
    {
        public danh_muc_san_pham()
        {
            this.san_pham = new HashSet<san_pham>();
        }

        [Display(Name = "Mã danh mục")]
        public int danh_muc_id { get; set; }

        [Display(Name = "Tên danh mục")]
        public string ten_danh_muc { get; set; }

        public virtual ICollection<san_pham> san_pham { get; set; }
    }
}
