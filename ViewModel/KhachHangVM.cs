using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class KhachHangVM
    {
        public string? TenKH { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? MaVaiTro { get; set; }
        public bool? Xoa { get; set; }

    }

    public class KhachHangMD : KhachHangVM
    {
        public int MaKH { get; set; }
        public virtual VaiTro VaiTro { get; set; }
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
    }

    public class AddKhachHangVM
    {
        public string? TenKH { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? MaVaiTro { get; set; } = 3;
        public bool? Xoa { get; set; } = false;
    }

    public class UpdateKhachHang
    {
        public string? TenKH { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }

    public class DeleteKhachHang
    {
        public bool? Xoa { get; set; }
    }



}