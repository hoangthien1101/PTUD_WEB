using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class TrangThaiPhongVM
    {
        public string? TenTT { get; set; }
    }

    public class TrangThaiPhongMD : TrangThaiPhongVM
    {
        public int MaTT { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }
    }

    public class AddTrangThaiPhong
    {
        public string? TenTT { get; set; }
    }

    public class UpdateTrangThaiPhong
    {
        public string? TenTT { get; set; }
    }
}