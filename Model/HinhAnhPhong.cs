using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class HinhAnhPhong
    {
        public int IdHinhAnh { get; set; }
        public string? path { get; set; }
        public bool? isUsed { get; set; }

        public int MaPhong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}