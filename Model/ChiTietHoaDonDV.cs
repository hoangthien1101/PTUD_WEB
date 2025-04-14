using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class ChiTietHoaDonDV
    {
        public int MaChiTiet { get; set; }
        public int MaHD { get; set; }
        public int MaDichVu { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? ThanhTien { get; set; }


        public virtual DichVu DichVu { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}