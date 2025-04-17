using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IHoaDonRepo
    {
        Task<JsonResult> AddHD(HoaDonVM hoaDonVM);
        JsonResult Delete(int id);
        List<HoaDonMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Update(int id, HoaDonVM hoaDonVM);
    }
    public class HoaDonRepo : IHoaDonRepo
    {
        private readonly AppDbContext _context;

        public HoaDonRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<HoaDonMD> GetAll()
        {
            var hoaDon = _context.HoaDons.Select(h => new HoaDonMD
            {
                MaHD = h.MaHD,
                MaKH = h.MaKH,  
                NgayLapHD = h.NgayLapHD,
                MaPhuongThuc = h.MaPhuongThuc,
                MaGiam = h.MaGiam,
                TongTien = h.TongTien,
                TrangThai = h.TrangThai
            }).ToList();
            return hoaDon;
        }   

        public JsonResult GetById(int id)
        {
            var hoaDon = _context.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return new JsonResult("Hóa đơn không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var hoaDonMD = new HoaDonVM
            {
                MaKH = hoaDon.MaKH,
                NgayLapHD = hoaDon.NgayLapHD,
                MaPhuongThuc = hoaDon.MaPhuongThuc,
                MaGiam = hoaDon.MaGiam,
                TongTien = hoaDon.TongTien,
                TrangThai = hoaDon.TrangThai
            };
            return new JsonResult(hoaDonMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public async Task<JsonResult> AddHD(HoaDonVM hoaDonVM)
        {
            var hoaDon = new HoaDon
            {   
                MaKH = hoaDonVM.MaKH,
                NgayLapHD = hoaDonVM.NgayLapHD,
                MaPhuongThuc = hoaDonVM.MaPhuongThuc,
                MaGiam = hoaDonVM.MaGiam,
                TongTien = hoaDonVM.TongTien,
                TrangThai = hoaDonVM.TrangThai
            };  
            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm hóa đơn thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(int id)
        {
            var hoaDon = _context.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return new JsonResult("Hóa đơn không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.HoaDons.Remove(hoaDon);
            _context.SaveChanges();
            return new JsonResult("Xóa hóa đơn thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public JsonResult Update(int id, HoaDonVM hoaDonVM)
        {
            var hoaDon = _context.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return new JsonResult("Hóa đơn không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            hoaDon.MaKH = hoaDonVM.MaKH;
            hoaDon.NgayLapHD = hoaDonVM.NgayLapHD;
            hoaDon.MaPhuongThuc = hoaDonVM.MaPhuongThuc;
            hoaDon.MaGiam = hoaDonVM.MaGiam;
            hoaDon.TongTien = hoaDonVM.TongTien;
            hoaDon.TrangThai = hoaDonVM.TrangThai;  
            _context.SaveChanges();
            return new JsonResult("Cập nhật hóa đơn thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   
    }
}