using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class CaLamVM
    {
        public string? TenCa { get; set; }
        public DateTime? GioBatDau { get; set; }
        public DateTime? GioKetThuc { get; set; }
    }
    public class CaLamMD : CaLamVM
    {
        public int Id { get; set; }
        // Navigation property
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}