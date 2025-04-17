using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class DatPhongVM
    {

        public int? MaKH { get; set; }
        public int? MaPhong { get; set; }

        public DateTime? NgayDat { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? TrangThai { get; set; }
        public bool? Xoa { get; set; }


    }

    public class DatPhongMD : DatPhongVM
    {
        public int MaDatPhong { get; set; }
        
        // Navigation properties 
        public virtual TrangThaiDatPhong TrangThaiDatPhong { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Phong Phong { get; set; }
    }

    public class AddDatPhong
    {
        public int? MaKH { get; set; }
        public int? MaPhong { get; set; }
        
        public DateTime? NgayDat { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? TrangThai { get; set; }
        public bool? Xoa { get; set; }
    }

    public class UpdateDatPhong
    {
        public int? MaKH { get; set; }
        public int? MaPhong { get; set; }

        public DateTime? NgayDat { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public int? TrangThai { get; set; }
    }

    public class DeleteDatPhong
    {
        public bool? Xoa { get; set; }
    }
}
