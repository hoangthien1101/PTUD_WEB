using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class TrangThaiDatPhongVM
    {
        public string? TenTT { get; set; }
    }

    public class TrangThaiDatPhongMD : TrangThaiDatPhongVM
    {
        public int MaTT { get; set; }
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
    }

    public class AddTrangThaiDatPhong
    {
        public string? TenTT { get; set; }
    }

    public class UpdateTrangThaiDatPhong
    {
        public string? TenTT { get; set; }
    }

}
