using System;

namespace MyWebApi.Model
{
    public class DatPhongMD
    {
        public int MaDatPhong { get; set; }
        public int MaKH { get; set; }
        public int MaPhong { get; set; }
        public string SoPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int TrangThai { get; set; }
        public bool Xoa { get; set; }
    }
} 