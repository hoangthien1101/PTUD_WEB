using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApi.Model;
using MyWebApi.Services;

namespace MyWebApi.ViewModel
{
    public class TrangThaiThanhToanVM
    {
        public string TenTT { get; set; }
    }
    public class TrangThaiThanhToanMD : TrangThaiThanhToanVM
    {
        public int Id { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}