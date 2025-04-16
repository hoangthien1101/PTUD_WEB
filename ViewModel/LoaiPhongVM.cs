using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class LoaiPhongVM
    {

        public string? TenLoai { get; set; }
        public decimal? GiaPhong { get; set; }
    }

    public class LoaiPhongMD : LoaiPhongVM
    {
        public int MaLoai { get; set; }
        public virtual ICollection<Phong> Phongs { get; set; }
    }

    public class AddLoaiPhong
    {
        public string? TenLoai { get; set; }
        public decimal? GiaPhong { get; set; }
    }

     public class UpdateLoaiPhong
    {
        public string? TenLoai { get; set; }
        public decimal? GiaPhong { get; set; }
    }
}