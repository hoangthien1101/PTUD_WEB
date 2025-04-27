using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IGiamGiaRepo
    {
        Task<JsonResult> AddGG(GiamGiaVM giamGiaVM);
        JsonResult Delete(int id);
        PaginationModel<GiamGiaMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, GiamGiaVM giamGiaVM);
    }
    public class GiamGiaRepo : IGiamGiaRepo
    {
        private readonly AppDbContext _context;

        public GiamGiaRepo(AppDbContext context)
        {   
            _context = context;
        }

        public PaginationModel<GiamGiaMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.GiamGias.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var giamGia = query.Select(g => new GiamGiaMD
            {
                Id = g.Id,
                TenMa = g.TenMa,
                LoaiGiam = g.LoaiGiam,
                GiaTri = g.GiaTri,
                NgayBatDau = g.NgayBatDau,
                NgayKetThuc = g.NgayKetThuc,
                TrangThai = g.TrangThai
            }).ToList();
            return new PaginationModel<GiamGiaMD>
            {
                Items = giamGia,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        }       
        
        public JsonResult GetById(int id)
        {
            var giamGia = _context.GiamGias.Find(id);
            if (giamGia == null)
            {
                return new JsonResult("Giảm giá không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var giamGiaMD = new GiamGiaVM
            {
                TenMa = giamGia.TenMa,
                LoaiGiam = giamGia.LoaiGiam,
                GiaTri = giamGia.GiaTri,
                NgayBatDau = giamGia.NgayBatDau,
                NgayKetThuc = giamGia.NgayKetThuc,
                TrangThai = giamGia.TrangThai
            };
            return new JsonResult(giamGiaMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> AddGG(GiamGiaVM giamGiaVM)
        {
            var check = _context.GiamGias.Any(g => g.TenMa == giamGiaVM.TenMa);
            if (check)
            {
                return new JsonResult("Mã giảm giá đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }       
            var giamGia = new GiamGia
            {
                TenMa = giamGiaVM.TenMa,
                LoaiGiam = giamGiaVM.LoaiGiam,
                GiaTri = giamGiaVM.GiaTri,
                NgayBatDau = giamGiaVM.NgayBatDau,
                NgayKetThuc = giamGiaVM.NgayKetThuc,
                TrangThai = giamGiaVM.TrangThai
            };
            _context.GiamGias.Add(giamGia);
            _context.SaveChanges();
            return new JsonResult("Thêm giảm giá thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        
        public JsonResult Delete(int id)
        {
            var giamGia = _context.GiamGias.Find(id);
            if (giamGia == null)
            {
                return new JsonResult("Giảm giá không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.GiamGias.Remove(giamGia);
            _context.SaveChanges();
            return new JsonResult("Xóa giảm giá thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Update(int id, GiamGiaVM giamGiaVM)
        {
            var giamGia = _context.GiamGias.Find(id);
            if (giamGia == null)
            {
                return new JsonResult("Giảm giá không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };  
            }
            giamGia.TenMa = giamGiaVM.TenMa;
            giamGia.LoaiGiam = giamGiaVM.LoaiGiam;
            giamGia.GiaTri = giamGiaVM.GiaTri;
            giamGia.NgayBatDau = giamGiaVM.NgayBatDau;
            giamGia.NgayKetThuc = giamGiaVM.NgayKetThuc;
            giamGia.TrangThai = giamGiaVM.TrangThai;
            _context.SaveChanges();
            return new JsonResult("Cập nhật giảm giá thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };  
        }
    }
}       