using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class TrangThaiThanhToan
    {
        public int Id { get; set; }
        public string TenTT { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}