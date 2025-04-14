using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public DateTime? NgayLapHD { get; set; }
        public int? MaPhuongThuc { get; set; }
        public int? MaGiam { get; set; }
        public decimal? TongTien { get; set; }
        public int? TrangThai { get; set; }

        // Navigation properties
        public virtual KhachHang KhachHang { get; set; }

        public virtual TrangThaiThanhToan TrangThaiThanhToan { get; set; }

        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }

        public virtual GiamGia GiamGia { get; set; }

        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }



    }
}