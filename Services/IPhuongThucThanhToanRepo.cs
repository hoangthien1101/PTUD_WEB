using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IPhuongThucThanhToanRepo
    {
        Task<JsonResult> AddPTTT(PhuongThucThanhToanVM phuongThucThanhToanVM);
        JsonResult Delete(int id);
        List<PhuongThucThanhToanMD> GetAll();
        JsonResult GetById(int id);
        JsonResult Update(int id, PhuongThucThanhToanVM phuongThucThanhToanVM);
    }
    public class PhuongThucThanhToanRepo : IPhuongThucThanhToanRepo
    {
        private readonly AppDbContext _context;

        public PhuongThucThanhToanRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<PhuongThucThanhToanMD> GetAll()
        {
            var phuongThucThanhToan = _context.PhuongThucThanhToans.Select(p => new PhuongThucThanhToanMD
            {
                Id = p.Id,
                TenPhuongThuc = p.TenPhuongThuc,
                MoTa = p.MoTa,
                TrangThai = p.TrangThai
            }).ToList();
            return phuongThucThanhToan;
        }

        public JsonResult GetById(int id)
        {
            var phuongThucThanhToan = _context.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null){
                return new JsonResult("Phương thức thanh toán không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var phuongThucThanhToanMD = new PhuongThucThanhToanVM
            {
                TenPhuongThuc = phuongThucThanhToan.TenPhuongThuc,
                MoTa = phuongThucThanhToan.MoTa,
                TrangThai = phuongThucThanhToan.TrangThai
            };
            return new JsonResult(phuongThucThanhToanMD)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> AddPTTT(PhuongThucThanhToanVM phuongThucThanhToanVM)
        {
            var check = _context.PhuongThucThanhToans.Any(p => p.TenPhuongThuc == phuongThucThanhToanVM.TenPhuongThuc);
            if (check)
            {
                return new JsonResult("Phương thức thanh toán đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var phuongThucThanhToan = new PhuongThucThanhToan
            {
                TenPhuongThuc = phuongThucThanhToanVM.TenPhuongThuc,
                MoTa = phuongThucThanhToanVM.MoTa,
                TrangThai = phuongThucThanhToanVM.TrangThai
            };
            _context.PhuongThucThanhToans.Add(phuongThucThanhToan);
            await _context.SaveChangesAsync();
            return new JsonResult("Phương thức thanh toán đã được thêm thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(int id)
        {
            var phuongThucThanhToan = _context.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return new JsonResult("Phương thức thanh toán không tồn tại");
            }
            _context.PhuongThucThanhToans.Remove(phuongThucThanhToan);
            _context.SaveChanges();
            return new JsonResult("Phương thức thanh toán đã được xóa thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Update(int id, PhuongThucThanhToanVM phuongThucThanhToanVM)
        {
            var phuongThucThanhToan = _context.PhuongThucThanhToans.Find(id);
            if (phuongThucThanhToan == null)
            {
                return new JsonResult("Phương thức thanh toán không tồn tại");
            }
            phuongThucThanhToan.TenPhuongThuc = phuongThucThanhToanVM.TenPhuongThuc;
            phuongThucThanhToan.MoTa = phuongThucThanhToanVM.MoTa;
            phuongThucThanhToan.TrangThai = phuongThucThanhToanVM.TrangThai;
            _context.SaveChanges();
            return new JsonResult("Phương thức thanh toán đã được cập nhật thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}