using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IDoanhThuRepo
    {
        JsonResult GetTongDoanhThu();
        JsonResult GetDoanhThuTheoNgay(DateTime ngay);
        JsonResult GetDoanhThuTheoThang(int thang, int nam);
        JsonResult GetDoanhThuTheoNam(int nam);
    }

    public class DoanhThuRepo : IDoanhThuRepo
    {
        private readonly AppDbContext _context;

        public DoanhThuRepo(AppDbContext context)
        {
            _context = context;
        }

        public JsonResult GetTongDoanhThu()
        {
            var tongDoanhThu = _context.HoaDons
                .Where(h => h.TrangThai == 1)
                .Sum(h => h.TongTien ?? 0);

            var result = new DoanhThuModel
            {
                TongDoanhThu = tongDoanhThu
            };

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult GetDoanhThuTheoNgay(DateTime ngay)
        {
            var doanhThu = _context.HoaDons
                .Where(h => h.TrangThai == 1 && 
                           h.NgayLapHD != null && 
                           h.NgayLapHD.Value.Date == ngay.Date)
                .Sum(h => h.TongTien ?? 0);

            var result = new DoanhThuModel
            {
                TongDoanhThu = doanhThu,
                Ngay = ngay
            };

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult GetDoanhThuTheoThang(int thang, int nam)
        {
            var doanhThu = _context.HoaDons
                .Where(h => h.TrangThai == 1 && 
                           h.NgayLapHD != null && 
                           h.NgayLapHD.Value.Month == thang && 
                           h.NgayLapHD.Value.Year == nam)
                .Sum(h => h.TongTien ?? 0);

            var result = new DoanhThuModel
            {
                TongDoanhThu = doanhThu,
                Thang = thang,
                Nam = nam
            };

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult GetDoanhThuTheoNam(int nam)
        {
            var doanhThu = _context.HoaDons
                .Where(h => h.TrangThai == 1 && 
                           h.NgayLapHD != null && 
                           h.NgayLapHD.Value.Year == nam)
                .Sum(h => h.TongTien ?? 0);

            var result = new DoanhThuModel
            {
                TongDoanhThu = doanhThu,
                Nam = nam
            };

            return new JsonResult(result)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
} 