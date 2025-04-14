using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class LoaiPhong
    {
        public int MaLoai { get; set; }
        public string? TenLoai { get; set; }
        public decimal? GiaPhong { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }

    }
}