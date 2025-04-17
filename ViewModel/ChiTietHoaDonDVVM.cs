using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class ChiTietHoaDonDVVM
    {
        public int MaHD { get; set; }
        public int MaDichVu { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }
    }
    public class ChiTietHoaDonDVMD : ChiTietHoaDonDVVM
    {
        public int MaChiTiet { get; set; }
        
        public virtual DichVu DichVu { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}