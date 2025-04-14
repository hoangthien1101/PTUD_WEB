using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class DatPhong
    {
        public int MaDatPhong { get; set; }
        public int? MaKH { get; set; }
        public int? MaPhong { get; set; }

        public DateTime? NgayDat { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? TrangThai { get; set; }
        public bool? Xoa { get; set; }

        // Navigation properties 
        public virtual TrangThaiDatPhong TrangThaiDatPhong { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Phong Phong { get; set; }

    }
}