using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.ViewModel;
using MyWebApi.Model;
namespace MyWebApi.Services
{
    public interface ILoaiPhongRepo
    {
        List<LoaiPhongMD> GetAll();
        JsonResult GetById(int id);
        Task<JsonResult> Create(AddLoaiPhong addLoaiPhong);
        JsonResult Update(int id, UpdateLoaiPhong updateLoaiPhong);
        JsonResult Delete(int id);
    }

    public class LoaiPhongRepo : ILoaiPhongRepo
    {
        private readonly AppDbContext _context;

        public LoaiPhongRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<LoaiPhongMD> GetAll()
        {
            return _context.LoaiPhongs.Select(lp => new LoaiPhongMD
            {
                MaLoai = lp.MaLoai,
                TenLoai = lp.TenLoai,
                GiaPhong = lp.GiaPhong
            }).ToList();
        }

        public JsonResult GetById(int id)
        {
            var loaiPhong = _context.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {
                return new JsonResult("Loại phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var loaiPhongVM = new LoaiPhongVM
            {
                TenLoai = loaiPhong.TenLoai,
                GiaPhong = loaiPhong.GiaPhong
            };
            return new JsonResult(loaiPhongVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> Create(AddLoaiPhong addLoaiPhong)
        {
            var check = _context.LoaiPhongs.FirstOrDefault(lp => lp.TenLoai == addLoaiPhong.TenLoai);
            if (check != null)
            {
                return new JsonResult("Loại phòng đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var loaiPhong = new LoaiPhong
            {
                TenLoai = addLoaiPhong.TenLoai,
                GiaPhong = addLoaiPhong.GiaPhong
            };
            _context.LoaiPhongs.Add(loaiPhong);
            _context.SaveChanges();
            return new JsonResult("Loại phòng đã được tạo thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public JsonResult Update(int id, UpdateLoaiPhong updateLoaiPhong)
        {
            var loaiPhong = _context.LoaiPhongs.Find(id);
            if (loaiPhong == null)
            {   
                return new JsonResult("Loại phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            loaiPhong.TenLoai = updateLoaiPhong.TenLoai;
            loaiPhong.GiaPhong = updateLoaiPhong.GiaPhong;
            _context.SaveChanges();
            return new JsonResult("Loại phòng đã được cập nhật thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public JsonResult Delete(int id)
        {
            var loaiPhong = _context.LoaiPhongs.FirstOrDefault(lp => lp.MaLoai == id);
            if (loaiPhong == null)
            {  
                return new JsonResult("Loại phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.LoaiPhongs.Remove(loaiPhong);
            _context.SaveChanges();
            return new JsonResult("Loại phòng đã được xóa thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

    }
}

