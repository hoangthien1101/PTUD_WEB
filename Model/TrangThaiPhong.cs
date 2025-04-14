using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class TrangThaiPhong
    {

        public int MaTT { get; set; }

        public string? TenTT { get; set; }

        public virtual ICollection<Phong> Phongs { get; set; }





    }
}