using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.ViewModel;
using MyWebApi.Model;
using MyWebApi.Service;

namespace MyWebApi.Services
{
    public interface IPhongRepo
    {
        List<PhongMD> GetAll();
        JsonResult GetBySoPhong(string SoPhong);
        Task<JsonResult> Create(AddPhong addPhong, List<IFormFile> files);
        JsonResult Update(string SoPhong, UpdatePhong updatePhong);
        JsonResult Delete(string SoPhong);
    }
    public class PhongRepo : IPhongRepo
    {
        private readonly AppDbContext _context;
        private readonly IWriteFileRepository _writeFile;
        private readonly IHinhAnhPhongService _hinhAnhPhong;

        public PhongRepo(AppDbContext context, IWriteFileRepository writeFile, IHinhAnhPhongService hinhAnhPhong)
        {
            _context = context;
            _writeFile = writeFile;
            _hinhAnhPhong = hinhAnhPhong;
        }

        public List<PhongMD> GetAll()
        {
            var phong = _context.Phongs.Select(p => new PhongMD
            {
                MaPhong = p.MaPhong,
                SoPhong = p.SoPhong,
                SoNguoi = p.SoNguoi,
                HinhAnh = p.HinhAnh,
                MoTa = p.MoTa,
                Xoa = p.Xoa,
                MaLoaiPhong = p.MaLoaiPhong,
                TrangThai = p.TrangThai,
            }).ToList();
            return phong;
        }

        public JsonResult GetBySoPhong(string SoPhong)
        {
            var phong = _context.Phongs.FirstOrDefault(p => p.SoPhong == SoPhong);
            if (phong == null)
            {
                return new JsonResult("Phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            var phongVM = new PhongVM
            {
                SoPhong = phong.SoPhong,
                SoNguoi = phong.SoNguoi,
                HinhAnh = phong.HinhAnh,
                MoTa = phong.MoTa,
                MaLoaiPhong = phong.MaLoaiPhong,
                TrangThai = phong.TrangThai,
            };  
            return new JsonResult(phongVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> Create(AddPhong addPhong, List<IFormFile> files)
        {
            var check = _context.Phongs.FirstOrDefault(p => p.SoPhong == addPhong.SoPhong);
            if (check == null)
            {
                var phong = new Phong
                {
                    SoPhong = addPhong.SoPhong,
                    SoNguoi = addPhong.SoNguoi,
                    // HinhAnh = addPhong.HinhAnh,
                    MoTa = addPhong.MoTa,
                    MaLoaiPhong = addPhong.MaLoaiPhong,
                    TrangThai = addPhong.TrangThai,
                };
                _context.Phongs.Add(phong);
                await _context.SaveChangesAsync();

                int MaPhong = phong.MaPhong;
                string folder = "Phong";

                List<string> imageUrls = await _writeFile.WriteFileAsync(files, folder);
                if (imageUrls.Count != 0)
                {
                    foreach (var url in imageUrls)
                    {
                        var image = new HinhAnhPhong
                        {
                            MaPhong = MaPhong,
                            path = url
                        };
                        _context.HinhAnhPhongs.Add(image);
                    }
                    _context.SaveChanges();
                }
                return new JsonResult("Thêm phòng thành công")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            return new JsonResult("Phòng đã tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        public JsonResult Update(string SoPhong, UpdatePhong updatePhong)
        {
            var phong = _context.Phongs.FirstOrDefault(p => p.SoPhong == SoPhong);
            if (phong == null)
            {
                return new JsonResult("Phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }   
            phong.SoPhong = updatePhong.SoPhong;
            phong.SoNguoi = updatePhong.SoNguoi;
            phong.HinhAnh = updatePhong.HinhAnh;
            phong.MoTa = updatePhong.MoTa;
            phong.MaLoaiPhong = updatePhong.MaLoaiPhong;
            phong.TrangThai = updatePhong.TrangThai;
            _context.SaveChangesAsync();
            return new JsonResult("Cập nhật phòng thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult Delete(string SoPhong)
        {
            var phong = _context.Phongs.FirstOrDefault(p => p.SoPhong == SoPhong);
            if (phong == null)
            {
                return new JsonResult("Phòng không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.Phongs.Remove(phong);
            _context.SaveChangesAsync();
            return new JsonResult("Xóa phòng thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

    }
}
