using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class DichVuVM
    {
        public string? Ten { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public decimal? Gia { get; set; }
        public int? TrangThai { get; set; } 
    }
    public class DichVuMD : DichVuVM
    {      
        public int MaDichVu { get; set; }
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }
       
    }
}