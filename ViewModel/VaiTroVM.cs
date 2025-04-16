using MyWebApi.Model;

namespace MyWebApi.ViewModel
{

    public class VaiTroVM
    {
        public string? TenLoai { get; set; }
    }

    public class VaiTroMD : VaiTroVM
    {
        public int MaLoai { get; set; }
        // Navigation property
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }

    public class AddVaiTro
    {
        public string? TenLoai { get; set; }
    }
}


