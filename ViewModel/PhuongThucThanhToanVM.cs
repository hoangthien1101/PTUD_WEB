using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Model;

namespace MyWebApi.ViewModel
{
    public class PhuongThucThanhToanVM
    {
        public string TenPhuongThuc { get; set; }
        public string? MoTa { get; set; }
        public bool? TrangThai { get; set; }
    }

    public class PhuongThucThanhToanMD : PhuongThucThanhToanVM
    {
        public int Id { get; set; }


        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}