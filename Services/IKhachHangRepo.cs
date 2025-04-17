using MyWebApi.Model;
using webAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.ViewModel
{
    public interface IKhachHangRepo
    {
        List<KhachHangMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Create(AddKhachHangVM khachHang);
        JsonResult Update(int id, UpdateKhachHang khachHang);
        JsonResult Delete(int id, DeleteKhachHang khachHang);
    }

    public class KhachHangRepo : IKhachHangRepo
    {
        private readonly AppDbContext _context;

        public KhachHangRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<KhachHangMD> GetAll()
        {
            var khachHangs = _context.KhachHangs.Select(kh => new KhachHangMD
            {
                MaKH = kh.MaKH,
                TenKH = kh.TenKH,
                Email = kh.Email,
                Phone = kh.Phone,
                Xoa = kh.Xoa
            }).ToList();
            return khachHangs;
        }

        public JsonResult GetById(int id)
        {
            var khachHang = _context.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return new JsonResult("Khách hàng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var khachHangVM = new KhachHangMD
            {
                TenKH = khachHang.TenKH,
                Email = khachHang.Email,
                Phone = khachHang.Phone,
                Xoa = khachHang.Xoa
            };
            return new JsonResult(khachHangVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Create(AddKhachHangVM khachHang)
        {
            var check = _context.KhachHangs.FirstOrDefault(kh => kh.Email == khachHang.Email);
            if (check != null)
            {
                return new JsonResult("Email đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var newKhachHang = new KhachHang
            {
                TenKH = khachHang.TenKH,
                Email = khachHang.Email,
                Phone = khachHang.Phone,
                Xoa = false,
            };
            _context.KhachHangs.Add(newKhachHang);
            _context.SaveChanges();
            return new JsonResult(newKhachHang)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public JsonResult Update(int id, UpdateKhachHang khachHang)
        {
            var check = _context.KhachHangs.Find(id);
            if (check == null)
            {
                return new JsonResult("Khách hàng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            check.TenKH = khachHang.TenKH;
            check.Email = khachHang.Email;
            _context.SaveChanges();
            return new JsonResult(check)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(int id, DeleteKhachHang khachHang)
        {
            var khachHangs = _context.KhachHangs.Find(id);
            if (khachHangs == null)
            {
                return new JsonResult("Khách hàng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            khachHangs.Xoa = khachHang.Xoa;
            _context.SaveChanges();
            return new JsonResult("Khách hàng đã được xóa")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}

