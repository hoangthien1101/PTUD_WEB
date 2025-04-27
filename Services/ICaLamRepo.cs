using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface ICaLamRepo
    {
        Task<JsonResult> AddCaLam(CaLamVM caLamVM);
        JsonResult Delete(int id);
        PaginationModel<CaLamMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, CaLamVM caLamVM);
    }
    public class CaLamRepo : ICaLamRepo
    {
        private readonly AppDbContext _context;

        public CaLamRepo(AppDbContext context)
        {
            _context = context;
        }

        public PaginationModel<CaLamMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.CaLams.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var caLams = query.Select(c => new CaLamMD
            {
                Id = c.Id,
                TenCa = c.TenCa,    
                GioBatDau = c.GioBatDau,
                GioKetThuc = c.GioKetThuc
            }).ToList();
            return new PaginationModel<CaLamMD>
            {
                Items = caLams,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        }

        public JsonResult GetById(int id)
        {
            var caLam = _context.CaLams.Find(id);
            if (caLam == null)
            {
                return new JsonResult("Ca làm không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var caLamMD = new CaLamVM
            {
                TenCa = caLam.TenCa,
                GioBatDau = caLam.GioBatDau,
                GioKetThuc = caLam.GioKetThuc
            };
            return new JsonResult(caLamMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> AddCaLam(CaLamVM caLamVM)
        {
            var check = _context.CaLams.Any(c => c.TenCa == caLamVM.TenCa);
            if (check)
            {
                return new JsonResult("Ca làm đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };      
            }
            var caLam = new CaLam
            {
                TenCa = caLamVM.TenCa,
                GioBatDau = caLamVM.GioBatDau,
                GioKetThuc = caLamVM.GioKetThuc
            };
            _context.CaLams.Add(caLam);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm ca làm thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   
        public JsonResult Delete(int id)
        {
            var caLam = _context.CaLams.Find(id);   
            if (caLam == null)
            {
                return new JsonResult("Ca làm không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };  
            }
            _context.CaLams.Remove(caLam);
            _context.SaveChanges();
            return new JsonResult("Xóa ca làm thành công")
            {
                StatusCode = StatusCodes.Status200OK    
            };
        }

        public JsonResult Update(int id, CaLamVM caLamVM)
        {
            var caLam = _context.CaLams.Find(id);   
            if (caLam == null)
            {
                return new JsonResult("Ca làm không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };  
            }
            caLam.TenCa = caLamVM.TenCa;
            caLam.GioBatDau = caLamVM.GioBatDau;
            caLam.GioKetThuc = caLamVM.GioKetThuc;
            _context.SaveChanges();
            return new JsonResult("Cập nhật ca làm thành công") 
            {
                StatusCode = StatusCodes.Status200OK    
            };
        }
    }
}