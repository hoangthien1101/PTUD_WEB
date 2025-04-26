using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.ViewModel;
using MyWebApi.Model;
namespace MyWebApi.Services
{
    public interface ILoaiPhongRepo
    {
        List<LoaiPhongMD> GetAll([FromQuery] PaginationParams paginationParams = null);
        JsonResult GetByMaLoai(int MaLoai);
        JsonResult Create(AddLoaiPhong addLoaiPhong);
        JsonResult Update(int MaLoai, UpdateLoaiPhong updateLoaiPhong);
        JsonResult Delete(int id);
    }

    public class LoaiPhongRepo : ILoaiPhongRepo
    {
        private readonly AppDbContext _context;

        public LoaiPhongRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<LoaiPhongMD> GetAll([FromQuery] PaginationParams paginationParams = null)
        {
            var query = _context.LoaiPhongs.AsQueryable();

            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }

            return query.Select(lp => new LoaiPhongMD
            {
                MaLoai = lp.MaLoai,
                TenLoai = lp.TenLoai,
                GiaPhong = lp.GiaPhong
            }).ToList();
        }

        public JsonResult GetByMaLoai(int MaLoai)
        {
            var loaiPhong = _context.LoaiPhongs.Find(MaLoai);
            if (loaiPhong == null)
            {
                return new JsonResult("Loại phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var loaiPhongMD = new LoaiPhongMD
            {
                TenLoai = loaiPhong.TenLoai,
                GiaPhong = loaiPhong.GiaPhong
            };
            return new JsonResult(loaiPhongMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Create(AddLoaiPhong addLoaiPhong)
        {
            var check = _context.LoaiPhongs.FirstOrDefault(lp => lp.TenLoai == addLoaiPhong.TenLoai);
            if (check == null)
            {
                var loaiPhong = new LoaiPhong
                {
                    TenLoai = addLoaiPhong.TenLoai,
                    GiaPhong = addLoaiPhong.GiaPhong
                };
                _context.LoaiPhongs.Add(loaiPhong);
                _context.SaveChanges();
                return new JsonResult("Thêm loại phòng thành công")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            return new JsonResult("Loại phòng đã tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }   

        public JsonResult Update(int MaLoai, UpdateLoaiPhong updateLoaiPhong)
        {
            var loaiPhong = _context.LoaiPhongs.Find(MaLoai);
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

