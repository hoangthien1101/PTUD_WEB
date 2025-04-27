using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface IChiTietHoaDonDVRepo
    {
        Task<JsonResult> AddCTHDDV(ChiTietHoaDonDVVM chiTietHoaDonDVVM);
        JsonResult Delete(int id);
        PaginationModel<ChiTietHoaDonDVMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, ChiTietHoaDonDVVM chiTietHoaDonDVVM);
    }
    public class ChiTietHoaDonDVRepo : IChiTietHoaDonDVRepo
    {
        private readonly AppDbContext _context;
        public ChiTietHoaDonDVRepo(AppDbContext context)
        {
            _context = context; 
        }
        public PaginationModel<ChiTietHoaDonDVMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.ChiTietHoaDonDVs.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var cthds = query.Select(c => new ChiTietHoaDonDVMD
            {
                MaChiTiet = c.MaChiTiet,
                MaHD = c.MaHD,
                MaDichVu = c.MaDichVu,
                SoLuong = c.SoLuong,
                DonGia = c.DonGia,
                ThanhTien = c.ThanhTien
            }).ToList();    
            return new PaginationModel<ChiTietHoaDonDVMD>
            {
                Items = cthds,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        }
        public JsonResult GetById(int id)
        {
            var cthd = _context.ChiTietHoaDonDVs.Find(id);
            if (cthd == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" });
            }
            var cthdVM = new ChiTietHoaDonDVMD
            {
                MaChiTiet = cthd.MaChiTiet,
                MaHD = cthd.MaHD,
                MaDichVu = cthd.MaDichVu,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
                ThanhTien = cthd.ThanhTien
            };
            return new JsonResult(cthdVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public async Task<JsonResult> AddCTHDDV(ChiTietHoaDonDVVM chiTietHoaDonDVVM)
        {
            var cthd = new ChiTietHoaDonDV
            {
                MaHD = chiTietHoaDonDVVM.MaHD,
                MaDichVu = chiTietHoaDonDVVM.MaDichVu,
                SoLuong = chiTietHoaDonDVVM.SoLuong,
                DonGia = chiTietHoaDonDVVM.DonGia,
                ThanhTien = chiTietHoaDonDVVM.ThanhTien
            };
            _context.ChiTietHoaDonDVs.Add(cthd);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Delete(int id)
        {
            var cthd = _context.ChiTietHoaDonDVs.Find(id);
            if (cthd == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" })
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.ChiTietHoaDonDVs.Remove(cthd);
            _context.SaveChanges();
            return new JsonResult(new { message = "Xóa thành công" })
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, ChiTietHoaDonDVVM chiTietHoaDonDVVM)
        {
            var cthd = _context.ChiTietHoaDonDVs.Find(id);
            if (cthd == null)
            {
                return new JsonResult(new { message = "Không tìm thấy dữ liệu" });
            }
            cthd.MaHD = chiTietHoaDonDVVM.MaHD;
            cthd.MaDichVu = chiTietHoaDonDVVM.MaDichVu;
            cthd.SoLuong = chiTietHoaDonDVVM.SoLuong;
            cthd.DonGia = chiTietHoaDonDVVM.DonGia;
            cthd.ThanhTien = chiTietHoaDonDVVM.ThanhTien;
            _context.SaveChanges();
            return new JsonResult(cthd)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }   
}