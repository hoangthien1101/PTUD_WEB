using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class GiamGiaVM
    {
        public string? TenMa { get; set; }
        public string? LoaiGiam { get; set; }
        public decimal? GiaTri { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public bool? TrangThai { get; set; }
    }
    public class GiamGiaMD : GiamGiaVM
    {
        public int Id { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}