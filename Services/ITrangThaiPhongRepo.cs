using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.ViewModel;
using MyWebApi.Model;

namespace MyWebApi.Services
{
    public interface ITrangThaiPhongRepo
    {
        List<TrangThaiPhongMD> GetAll(PaginationParams paginationParams);
        JsonResult GetByMaTT(int MaTT);
        JsonResult Create(AddTrangThaiPhong addTrangThaiPhong);
        JsonResult Update(int id, UpdateTrangThaiPhong updateTrangThaiPhong);
        JsonResult Delete(int id);
    }
    public class TrangThaiPhongRepo : ITrangThaiPhongRepo
    {
        private readonly AppDbContext _context;

        public TrangThaiPhongRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<TrangThaiPhongMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.TrangThaiPhongs.AsQueryable();

            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }

            return query.Select(tt => new TrangThaiPhongMD
            {
                MaTT = tt.MaTT,
                TenTT = tt.TenTT
            }).ToList();
        }
        public JsonResult GetByMaTT(int MaTT)
        {
            var trangThaiPhong = _context.TrangThaiPhongs.FirstOrDefault(tt => tt.MaTT == MaTT);
            if (trangThaiPhong == null)
            {
                return new JsonResult("Trạng thái phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var trangThaiPhongVM = new TrangThaiPhongVM
            {
                TenTT = trangThaiPhong.TenTT
            };
            return new JsonResult(trangThaiPhongVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Create(AddTrangThaiPhong addTrangThaiPhong)
        {
            var check = _context.TrangThaiPhongs.FirstOrDefault(tt => tt.TenTT == addTrangThaiPhong.TenTT);
            if (check != null)
            {
                return new JsonResult("Trạng thái phòng đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var trangThaiPhong = new TrangThaiPhong
            {
                TenTT = addTrangThaiPhong.TenTT
            };
            _context.TrangThaiPhongs.Add(trangThaiPhong);
            _context.SaveChanges();
            return new JsonResult("Trạng thái phòng đã được tạo thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, UpdateTrangThaiPhong updateTrangThaiPhong)
        {
            var trangThaiPhong = _context.TrangThaiPhongs.FirstOrDefault(tt => tt.MaTT == id);
            if (trangThaiPhong == null)
            {
                return new JsonResult("Trạng thái phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            trangThaiPhong.TenTT = updateTrangThaiPhong.TenTT;  
            _context.SaveChangesAsync();
            return new JsonResult("Trạng thái phòng đã được cập nhật thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };  
        }
        public JsonResult Delete(int id)
        {
            var trangThaiPhong = _context.TrangThaiPhongs.FirstOrDefault(tt => tt.MaTT == id);
            if (trangThaiPhong == null)
            {
                return new JsonResult("Trạng thái phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.TrangThaiPhongs.Remove(trangThaiPhong);
            _context.SaveChangesAsync();
            return new JsonResult("Trạng thái phòng đã được xóa thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
