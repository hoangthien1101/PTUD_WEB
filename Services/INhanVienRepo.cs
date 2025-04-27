using Microsoft.AspNetCore.Mvc;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using webAPI.Data;

namespace MyWebApi.Services
{
    public interface INhanVienRepo
    {
        Task<JsonResult> AddNV(NhanVienVM nhanVienVM);
        JsonResult Delete(int id);
        PaginationModel<NhanVienMD> GetAll(PaginationParams paginationParams);
        JsonResult GetById(int id);
        JsonResult Update(int id, NhanVienVM nhanVienVM);
    }
    public class NhanVienRepo : INhanVienRepo
    {
        private readonly AppDbContext _context;

        public NhanVienRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> AddNV(NhanVienVM nhanVienVM)
        {
            var nhanVien = new NhanVien
            {
                HoTen = nhanVienVM.HoTen,
                ChucVuId = nhanVienVM.ChucVuId,
                CaLamId = nhanVienVM.CaLamId,
                LuongCoBan = nhanVienVM.LuongCoBan,
                MaVaiTro = nhanVienVM.MaVaiTro,
                TrangThai = nhanVienVM.TrangThai
            };
            _context.NhanViens.Add(nhanVien);
            await _context.SaveChangesAsync();
            return new JsonResult("Thêm nhân viên thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }      
        public JsonResult Delete(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return new JsonResult("Nhân viên không tồn tại"){
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.NhanViens.Remove(nhanVien);
            _context.SaveChanges();
            return new JsonResult("Xóa nhân viên thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }   
        public PaginationModel<NhanVienMD> GetAll(PaginationParams paginationParams)
        {
            var query = _context.NhanViens.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var items = query.Select(n => new NhanVienMD
            {
                Id = n.Id,
                HoTen = n.HoTen,
                ChucVuId = n.ChucVuId,
                CaLamId = n.CaLamId,
                LuongCoBan = n.LuongCoBan,
                MaVaiTro = n.MaVaiTro,
                TrangThai = n.TrangThai
            }).ToList();
            return new PaginationModel<NhanVienMD>
            {
                Items = items,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
        }
        public JsonResult GetById(int id)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return new JsonResult("Nhân viên không tồn tại"){
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var nhanVienMD = new NhanVienVM
            {
                HoTen = nhanVien.HoTen,
                ChucVuId = nhanVien.ChucVuId,
                CaLamId = nhanVien.CaLamId,
                LuongCoBan = nhanVien.LuongCoBan,
                MaVaiTro = nhanVien.MaVaiTro,
                TrangThai = nhanVien.TrangThai
            };
            return new JsonResult(nhanVienMD){
                StatusCode = StatusCodes.Status200OK
            };
        }
        public JsonResult Update(int id, NhanVienVM nhanVienVM)
        {
            var nhanVien = _context.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return new JsonResult("Nhân viên không tồn tại"){
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            nhanVien.HoTen = nhanVienVM.HoTen;
            nhanVien.ChucVuId = nhanVienVM.ChucVuId;
            nhanVien.CaLamId = nhanVienVM.CaLamId;
            nhanVien.LuongCoBan = nhanVienVM.LuongCoBan;
            nhanVien.MaVaiTro = nhanVienVM.MaVaiTro;
            nhanVien.TrangThai = nhanVienVM.TrangThai;
            _context.SaveChanges();
            return new JsonResult("Nhân viên đã được cập nhật thành công"){
                StatusCode = StatusCodes.Status200OK
            };
        }   
    }
}