using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class GiamGia
    {
        public int Id { get; set; }
        public string? TenMa { get; set; }
        public string? LoaiGiam { get; set; }
        public decimal? GiaTri { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        public bool? TrangThai { get; set; }



        public virtual ICollection<HoaDon> HoaDons { get; set; }





    }
}