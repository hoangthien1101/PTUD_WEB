using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class UserVM
    {
        public int MaTK { get; set; }
        public string? TenTK { get; set; }
        public string? MatKhau { get; set; }
        public string? HinhAnh { get; set; }
        public string? TenHienThi { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public bool? IsVerified { get; set; }

        public DateTime CreateAt { get; set; }
        public bool? Xoa { get; set; }
        public string? TenLoai { get; set; }
        // Navigation property
        public int? LoaiTK { get; set; }
        public virtual VaiTro VaiTro { get; set; }
    }

    public class AddUser
    {
        public string? TenTK { get; set; }
        public string? MatKhau { get; set; }
        public string? TenHienThi { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateAt { get; set; }
        public int? LoaiTK { get; set; }
    }
    public class EditUser
    {
        public string? TenHienThi { get; set; }
        public string? Phone { get; set; }
    }

    public class RegisterUser
    {
        public int MaTK { get; set; }
        public string? TenTK { get; set; }
        public string? MatKhau { get; set; }
        public string? ReMatKhau { get; set; }
        public string? TenHienThi { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class DoiMatKhauVM
    {
        public string MatKhauCu { get; set; }
        public string MatKhauMoi { get; set; }
        public string ReMatKhau { get; set; }
    }
}
