using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class DichVu
    {
        public int MaDichVu { get; set; }
        public string? Ten { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }
        public decimal? Gia { get; set; }
        public int? TrangThai { get; set; }


        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
        public virtual ICollection<ChiTietHoaDonDV> ChiTietHoaDonDVs { get; set; }
    }
}