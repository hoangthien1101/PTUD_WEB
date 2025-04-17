using MyWebApi.Model;


namespace MyWebApi.ViewModel
{
    public class NhanVienVM
    {
        public string? HoTen { get; set; }
        public int? ChucVuId { get; set; }
        public int? CaLamId { get; set; }
        public decimal? LuongCoBan { get; set; }

        public int? MaVaiTro { get; set; }
        public bool? TrangThai { get; set; }

    }
     public class NhanVienMD : NhanVienVM
    {
        public int Id { get; set; }

        // Navigation properties
        public virtual VaiTro VaiTro { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual CaLam CaLam { get; set; }
    }
}