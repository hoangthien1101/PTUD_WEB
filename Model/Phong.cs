using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class Phong
    {
        public int MaPhong { get; set; }
        public string? SoPhong { get; set; }
        public int? SoNguoi { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }

        public bool? Xoa { get; set; }
        //Navigation
        public int? MaLoaiPhong { get; set; }
        public LoaiPhong LoaiPhong { get; set; }

        public int? TrangThai { get; set; }
        public virtual TrangThaiPhong TrangThaiPhong { get; set; }

        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        public virtual ICollection<HinhAnhPhong> HinhAnhPhongs { get; set; }


    }
}