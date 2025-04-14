using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    [Table("tbl_NhanVien")]
    public class NhanVien
    {
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public int? ChucVuId { get; set; }
        public int? CaLamId { get; set; }
        public decimal? LuongCoBan { get; set; }

        public int? MaVaiTro { get; set; }
        public bool? TrangThai { get; set; }


        // Navigation properties
        public virtual VaiTro VaiTro { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual CaLam CaLam { get; set; }
    }
}