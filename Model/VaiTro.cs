using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    [Table("tbl_VaiTro")]
    public class VaiTro
    {

        public int MaLoai { get; set; }
        public string? TenLoai { get; set; }



        // Navigation property
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}