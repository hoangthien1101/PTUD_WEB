using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class ChucVuVM
    {
        public string? TenChucVu { get; set; }
    }
     public class ChucVuMD : ChucVuVM
    { 
        public int Id { get; set; }
        // Navigation property
        public ICollection<NhanVien> NhanViens { get; set; }
    }
}