using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MyWebApi.Model
{
    [Table("tbl_TaiKhoan")]
    public class TaiKhoan
    {

        public int MaTK { get; set; }
        public string? TenTK { get; set; }
        public string? MatKhau { get; set; }
        public string? HinhAnh { get; set; }
        public string? TenHienThi { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime CreateAt { get; set; }
        public bool? Xoa { get; set; }

        
        // Navigation property
        public int? LoaiTK { get; set; }
        public virtual VaiTro VaiTro { get; set; }

    }
}