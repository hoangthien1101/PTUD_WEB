using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class PhuongThucThanhToan
    {
        public int Id { get; set; }
        public string TenPhuongThuc { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}