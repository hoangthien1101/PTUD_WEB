using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class SuDungDichVu
    {
        public int MaSDDV { get; set; }
        public int? MaKH { get; set; }
        public int? MaDV { get; set; }
        public DateTime? NgaySD { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }
        public string? TrangThai { get; set; }
        public bool? Xoa { get; set; }


        public virtual DichVu DichVu { get; set; }
        public virtual KhachHang KhachHang { get; set; }


    }
}