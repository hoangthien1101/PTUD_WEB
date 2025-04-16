using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using MyWebApi.Data;
using webAPI.Data;
using MyWebApi.Helper;

namespace MyWebApi.Services
{
    public interface ITrangThaiThanhToanRepo
    {
        Task<JsonResult> AddTT(TrangThaiThanhToanVM trangThaiThanhToanVM);
        JsonResult Delete(int id);
        List<TrangThaiThanhToanMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Update(int id, TrangThaiThanhToanVM trangThaiThanhToanVM);
        //  GetById(int id);   
    }
    public class TrangThaiThanhToanRepo : ITrangThaiThanhToanRepo
    {
        private readonly AppDbContext _context;

        public TrangThaiThanhToanRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<TrangThaiThanhToanMD> GetAll()
        {
            var trangThaiThanhToan = _context.TrangThaiThanhToans.Select(t => new TrangThaiThanhToanMD
            {
                Id = t.Id,
                TenTT = t.TenTT
            }).ToList();
            return trangThaiThanhToan;
        }
        public JsonResult GetById(int id)
        {
            var trangThaiThanhToan = _context.TrangThaiThanhToans.Find(id);
            if (trangThaiThanhToan == null)
            {
                return new JsonResult("Không tìm thấy trạng thái thanh toán")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var trangThaiThanhToanMD = new TrangThaiThanhToanVM {
                TenTT = trangThaiThanhToan.TenTT
            };
            return new JsonResult(trangThaiThanhToanMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public async Task<JsonResult> AddTT(TrangThaiThanhToanVM trangThaiThanhToanVM)
        {
            var check = _context.TrangThaiThanhToans.Any(t => t.TenTT == trangThaiThanhToanVM.TenTT);
            if (check)
            {
                return new JsonResult("Trạng thái thanh toán đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var trangThaiThanhToan = new TrangThaiThanhToan {
                TenTT = trangThaiThanhToanVM.TenTT
            };
            _context.TrangThaiThanhToans.Add(trangThaiThanhToan);
            _context.SaveChanges();
            return new JsonResult("Trạng thái thanh toán đã được thêm")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(int id)
        {
            var trangThaiThanhToan = _context.TrangThaiThanhToans.Find(id);
            if (trangThaiThanhToan == null)
            {
                return new JsonResult("Không tìm thấy trạng thái thanh toán")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.TrangThaiThanhToans.Remove(trangThaiThanhToan);
            _context.SaveChanges();
            return new JsonResult("Trạng thái thanh toán đã được xóa")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, TrangThaiThanhToanVM trangThaiThanhToanVM)
        {
            var trangThaiThanhToan = _context.TrangThaiThanhToans.Find(id);
            if (trangThaiThanhToan == null)
            {
                return new JsonResult("Không tìm thấy trạng thái thanh toán")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            trangThaiThanhToan.TenTT = trangThaiThanhToanVM.TenTT;
            _context.SaveChanges();
            return new JsonResult("Trạng thái thanh toán đã được cập nhật")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}

