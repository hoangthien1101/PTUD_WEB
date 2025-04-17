using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class HoaDonVM
    {
        public int MaKH { get; set; }
        public DateTime? NgayLapHD { get; set; }
        public int? MaPhuongThuc { get; set; }
        public int? MaGiam { get; set; }
        public decimal? TongTien { get; set; }
        public int? TrangThai { get; set; }
    }
    public class HoaDonMD : HoaDonVM
    {
        public int MaHD { get; set; } 
        // Navigation properties
        public virtual KhachHang KhachHang { get; set; }

        public virtual TrangThaiThanhToan TrangThaiThanhToan { get; set; }

        public virtual PhuongThucThanhToan PhuongThucThanhToan { get; set; }

        public virtual GiamGia GiamGia { get; set; }

        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }
    }
}