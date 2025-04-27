using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface ISuDungDichVuRepo
    {
        Task<JsonResult> AddSDDV(SuDungDichVuVM suDungDichVuVM);
        JsonResult Delete(int id);
        PaginationModel<SuDungDichVuMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, SuDungDichVuVM suDungDichVuVM);
    }
    public class SuDungDichVuRepo : ISuDungDichVuRepo
    {
        private readonly AppDbContext _context;

        public SuDungDichVuRepo(AppDbContext context)
        {
            _context = context;
        }

        public PaginationModel<SuDungDichVuMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.SuDungDichVus.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var suDungDichVus = query.Select(s => new SuDungDichVuMD
            {
                MaSDDV = s.MaSDDV,
                MaKH = s.MaKH,
                MaDV = s.MaDV,
                NgaySD = s.NgaySD,
                SoLuong = s.SoLuong,
                ThanhTien = s.ThanhTien,
                TrangThai = s.TrangThai,
                Xoa = s.Xoa 
            }).ToList();
            return new PaginationModel<SuDungDichVuMD>
            {
                Items = suDungDichVus,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        }

        public JsonResult GetById(int id)
        {
            var suDungDichVu = _context.SuDungDichVus.Find(id);
            if (suDungDichVu == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" });
            }
            var suDungDichVuVM = new SuDungDichVuVM
            {
                MaKH = suDungDichVu.MaKH,
                MaDV = suDungDichVu.MaDV,
                NgaySD = suDungDichVu.NgaySD,
                SoLuong = suDungDichVu.SoLuong,
                ThanhTien = suDungDichVu.ThanhTien,
                TrangThai = suDungDichVu.TrangThai,
                Xoa = suDungDichVu.Xoa
            };
            return new JsonResult(suDungDichVuVM){
                StatusCode = StatusCodes.Status200OK
            };
        }   
        public async Task<JsonResult> AddSDDV(SuDungDichVuVM suDungDichVuVM)
        {
            var suDungDichVu = new SuDungDichVu
            {
                MaKH = suDungDichVuVM.MaKH,
                MaDV = suDungDichVuVM.MaDV, 
                NgaySD = suDungDichVuVM.NgaySD,
                SoLuong = suDungDichVuVM.SoLuong,
                ThanhTien = suDungDichVuVM.ThanhTien,
                TrangThai = suDungDichVuVM.TrangThai,
                Xoa = suDungDichVuVM.Xoa
            };  
            _context.SuDungDichVus.Add(suDungDichVu);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm thành công"){
                StatusCode = StatusCodes.Status201Created
            };
        }
        public JsonResult Delete(int id)
        {   
            var suDungDichVu = _context.SuDungDichVus.Find(id);
            if (suDungDichVu == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" });
            }
            suDungDichVu.Xoa = false;
            _context.SaveChanges();
            return new JsonResult("Xóa thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, SuDungDichVuVM suDungDichVuVM)
        {
            var suDungDichVu = _context.SuDungDichVus.Find(id);
            if (suDungDichVu == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" });
            }
            suDungDichVu.MaKH = suDungDichVuVM.MaKH;
            suDungDichVu.MaDV = suDungDichVuVM.MaDV;
            suDungDichVu.NgaySD = suDungDichVuVM.NgaySD;    
            suDungDichVu.SoLuong = suDungDichVuVM.SoLuong;
            suDungDichVu.ThanhTien = suDungDichVuVM.ThanhTien;
            suDungDichVu.TrangThai = suDungDichVuVM.TrangThai;
            suDungDichVu.Xoa = suDungDichVuVM.Xoa;
            _context.SaveChanges();
            return new JsonResult("Cập nhật thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }   
    }
}