using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IDichVuRepo
    {
        Task<JsonResult> AddDV(DichVuVM dichVuVM);
        JsonResult Delete(int id);
        PaginationModel<DichVuMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, DichVuVM dichVuVM);
    }
    public class DichVuRepo : IDichVuRepo
    {
        private readonly AppDbContext _context;

        public DichVuRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> AddDV(DichVuVM dichVuVM)
        {
            var check = _context.DichVus.Any(d => d.Ten == dichVuVM.Ten);
            if (check)
            {
                return new JsonResult("Dịch vụ đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };  
            }
            var dichVu = new DichVu
            {
                Ten = dichVuVM.Ten,
                HinhAnh = dichVuVM.HinhAnh,
                MoTa = dichVuVM.MoTa,
                Gia = dichVuVM.Gia,
                TrangThai = dichVuVM.TrangThai
            };
            _context.DichVus.Add(dichVu);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm dịch vụ thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
                    
        public JsonResult Delete(int id)
        {
            var dichVu = _context.DichVus.Find(id);
            if (dichVu == null)
            {
                return new JsonResult("Dịch vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.DichVus.Remove(dichVu);
            _context.SaveChanges();
            return new JsonResult("Xóa dịch vụ thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public PaginationModel<DichVuMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.DichVus.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var dichVus = query.Select(d => new DichVuMD
            {
                MaDichVu = d.MaDichVu,
                Ten = d.Ten,
                HinhAnh = d.HinhAnh,
                MoTa = d.MoTa,
                Gia = d.Gia,
                TrangThai = d.TrangThai
            }).ToList();
            return new PaginationModel<DichVuMD>
            {
                Items = dichVus,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        } 
        public JsonResult GetById(int id)
        {
            var dichVu = _context.DichVus.Find(id);
            if (dichVu == null) 
            {
                return new JsonResult("Dịch vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            var dichVuMD = new DichVuVM
            {
                Ten = dichVu.Ten,
                HinhAnh = dichVu.HinhAnh,
                MoTa = dichVu.MoTa,
                Gia = dichVu.Gia,
                TrangThai = dichVu.TrangThai
            };
            return new JsonResult(dichVuMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, DichVuVM dichVuVM)
        {
            var dichVu = _context.DichVus.Find(id);
            if (dichVu == null){
                return new JsonResult("Dịch vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            dichVu.Ten = dichVuVM.Ten;
            dichVu.HinhAnh = dichVuVM.HinhAnh;
            dichVu.MoTa = dichVuVM.MoTa;
            dichVu.Gia = dichVuVM.Gia;
            dichVu.TrangThai = dichVuVM.TrangThai;
            _context.SaveChanges();
            return new JsonResult("Cập nhật dịch vụ thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }       
    }
}
