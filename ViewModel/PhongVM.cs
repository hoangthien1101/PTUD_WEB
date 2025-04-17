using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class PhongVM
    {
        public string? SoPhong { get; set; }
        public int? SoNguoi { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }

        public bool? Xoa { get; set; }
        //Navigation
        public int? MaLoaiPhong { get; set; }

        public string? TenLoaiPhong { get; set; }
        public virtual LoaiPhong LoaiPhong { get; set; }
        public virtual TrangThaiPhong TrangThaiPhong { get; set; }

        public int? TrangThai { get; set; }
        public string? TenTT { get; set; }
    }
    public class PhongMD : PhongVM
    {
        public int MaPhong { get; set; }
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        public virtual ICollection<HinhAnhPhong> HinhAnhPhongs { get; set; }
    }

    public class AddPhong
    {
        public string? SoPhong { get; set; }
        public int? SoNguoi { get; set; }
        // public string? HinhAnh { get; set;}
        public string? MoTa { get; set; }
        public int? MaLoaiPhong { get; set; }
        public int? TrangThai { get; set; }
    }

    public class UpdatePhong
    {
        public string? SoPhong { get; set; }
        public int? SoNguoi { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public int? MaLoaiPhong { get; set; }
        public int? TrangThai { get; set; }
    }
    public class DeletePhong
    {
        public bool? Xoa { get; set; }
    }
}
