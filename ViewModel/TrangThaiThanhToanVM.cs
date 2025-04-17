using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class TrangThaiThanhToanVM
    {
        public string TenTT { get; set; }
    }
    public class TrangThaiThanhToanMD : TrangThaiThanhToanVM
    {
        public int Id { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}