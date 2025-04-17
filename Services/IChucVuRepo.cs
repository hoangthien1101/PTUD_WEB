using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IChucVuRepo
    {
        Task<JsonResult> AddCV(ChucVuVM chucVuVM);
        JsonResult Delete(int id);
        List<ChucVuMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Update(int id, ChucVuVM chucVuVM);
    }
    public class ChucVuRepo : IChucVuRepo
    {
        private readonly AppDbContext _context;

        public ChucVuRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<ChucVuMD> GetAll()
        {
            var chucVus = _context.ChucVus.Select(c => new ChucVuMD
            {
                Id = c.Id,
                TenChucVu = c.TenChucVu 
            }).ToList();
            return chucVus;
        }

        public JsonResult GetById(int id)
        {
            var chucVu = _context.ChucVus.Find(id);
            if (chucVu == null)
            {
                return new JsonResult("Chức vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var chucVuMD = new ChucVuVM
            {
                TenChucVu = chucVu.TenChucVu
            };
            return new JsonResult(chucVuMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        
        public async Task<JsonResult> AddCV(ChucVuVM chucVuVM)
        {
           var check = _context.ChucVus.Any(c => c.TenChucVu == chucVuVM.TenChucVu);
           if (check)
           {
            return new JsonResult("Chức vụ đã tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
           }
           var chucVu = new ChucVu
           {
            TenChucVu = chucVuVM.TenChucVu
           };
           _context.ChucVus.Add(chucVu);
           await _context.SaveChangesAsync();
           return new JsonResult("Thêm chức vụ thành công")
           {
            StatusCode = StatusCodes.Status200OK
           };   
        }       

        public JsonResult Delete(int id)
        {
            var chucVu = _context.ChucVus.Find(id);
            if (chucVu == null) 
            {
                return new JsonResult("Chức vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            _context.ChucVus.Remove(chucVu);
            _context.SaveChanges();
            return new JsonResult("Xóa chức vụ thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public JsonResult Update(int id, ChucVuVM chucVuVM)
        {
            var chucVu = _context.ChucVus.Find(id);
            if (chucVu == null) 
            {
                return new JsonResult("Chức vụ không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            chucVu.TenChucVu = chucVuVM.TenChucVu;
            _context.SaveChanges();
            return new JsonResult("Cập nhật chức vụ thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }      
    }
}