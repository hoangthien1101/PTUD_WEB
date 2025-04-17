using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.ViewModel;
using MyWebApi.Model;
using MyWebApi.Service;

namespace MyWebApi.Services
{
    public interface ITrangThaiDatPhongRepo
    {
        List<TrangThaiDatPhongMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Create(AddTrangThaiDatPhong addTrangThaiDatPhong);
        JsonResult Update(int id, UpdateTrangThaiDatPhong updateTrangThaiDatPhong);
        JsonResult Delete(int id);
    }
    
    public class TrangThaiDatPhongRepo : ITrangThaiDatPhongRepo
    {
        private readonly AppDbContext _context;

        public TrangThaiDatPhongRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<TrangThaiDatPhongMD> GetAll()
        {
            return _context.TrangThaiDatPhongs.Select(t => new TrangThaiDatPhongMD
            {
                MaTT = t.MaTT,
                TenTT = t.TenTT
            }).ToList();
        }

        public JsonResult GetById(int id)
        {
            var trangThaiDatPhong = _context.TrangThaiDatPhongs.Find(id);
            if (trangThaiDatPhong == null)
            {
                return new JsonResult("Trang thái đặt phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var trangThaiDatPhongVM = new TrangThaiDatPhongMD
            {
                MaTT = trangThaiDatPhong.MaTT,
                TenTT = trangThaiDatPhong.TenTT
            };
            return new JsonResult(trangThaiDatPhongVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Create(AddTrangThaiDatPhong addTrangThaiDatPhong)
        {
            var check = _context.TrangThaiDatPhongs.FirstOrDefault(t => t.TenTT == addTrangThaiDatPhong.TenTT);
            if (check != null)
            {
                return new JsonResult("Trạng thái đặt phòng đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var trangThaiDatPhong = new TrangThaiDatPhong
            {
                TenTT = addTrangThaiDatPhong.TenTT
            };
            _context.TrangThaiDatPhongs.Add(trangThaiDatPhong);
            _context.SaveChanges();
            return new JsonResult("Thêm trạng thái đặt phòng thành công")
            {
                StatusCode = StatusCodes.Status201Created
            };

        }

        public JsonResult Update(int id, UpdateTrangThaiDatPhong updateTrangThaiDatPhong)
        {
            var trangThaiDatPhong = _context.TrangThaiDatPhongs.Find(id);
            if (trangThaiDatPhong == null)
            {
                return new JsonResult("Trạng thái đặt phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            trangThaiDatPhong.TenTT = updateTrangThaiDatPhong.TenTT;
            _context.SaveChanges();
            return new JsonResult("Cập nhật trạng thái đặt phòng thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(int id)
        {
            var trangThaiDatPhong = _context.TrangThaiDatPhongs.Find(id);
            if (trangThaiDatPhong == null)
            {
                return new JsonResult("Trạng thái đặt phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.TrangThaiDatPhongs.Remove(trangThaiDatPhong);
            _context.SaveChanges();
            return new JsonResult("Xóa trạng thái đặt phòng thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
