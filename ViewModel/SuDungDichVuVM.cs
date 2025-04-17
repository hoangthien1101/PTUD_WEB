using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class SuDungDichVuVM
    {
        public int? MaKH { get; set; }
        public int? MaDV { get; set; }
        public DateTime? NgaySD { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? TrangThai { get; set; }
        public bool? Xoa { get; set; }
    }
    public class SuDungDichVuMD : SuDungDichVuVM
    {
        public int MaSDDV { get; set; }
        public virtual DichVu DichVu { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}