using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Model
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string? TenKH { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? MaVaiTro { get; set; }
        public bool? Xoa { get; set; }


        public virtual VaiTro VaiTro { get; set; }
        public virtual ICollection<DatPhong> DatPhongs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<SuDungDichVu> SuDungDichVus { get; set; }
    }
}