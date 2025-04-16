using MyWebApi.Model;
using webAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.ViewModel
{
    public interface IHinhAnhPhongService
    {
        Task<List<string>> WriteFileAsync(List<IFormFile> files, int MaPhong, bool isUsed, string folder);
        List<HinhAnhPhongVM> GetImagesByPhong(int maPhong);
        JsonResult DeleteImage(int id);
        JsonResult SetAvatar(int id);
        JsonResult UpdateImage(int id, UpdateHinhAnh model);
    }

    public class HinhAnhPhongService : IHinhAnhPhongService
    {
        private readonly AppDbContext _context;

        public HinhAnhPhongService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> WriteFileAsync(List<IFormFile> files, int MaPhong, bool isUsed, string folder)
        {
            var imageUrls = new List<string>();
            var errorMessages = new List<string>();

            foreach (var file in files)
            {
                if (file.Length == 0)
                {
                    continue;
                }

                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    errorMessages.Add($"File không hợp lệ '{file.FileName}'. Chỉ chấp nhận file ảnh (jpg, jpeg, png)");
                    continue;
                }

                try
                {
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    string result = $"uploads/{uniqueFileName}";
                    imageUrls.Add(result);
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"Lỗi khi upload file '{file.FileName}': {ex.Message}");
                }
            }

            if (errorMessages.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, errorMessages));
            }

            var Phong = _context.Phongs.FirstOrDefault(u => u.MaPhong == MaPhong);
            if (Phong == null)
            {
                throw new Exception("Không tìm thấy phòng.");
            }

            foreach (var imageUrl in imageUrls)
            {
                var image = new HinhAnhPhong
                {
                    path = imageUrl,
                    MaPhong = Phong.MaPhong,
                    isUsed = isUsed,
                };
                _context.HinhAnhPhongs.Add(image);
            }
            await _context.SaveChangesAsync();
            return imageUrls;
        }

        public List<HinhAnhPhongVM> GetImagesByPhong(int maPhong)
        {
            var images = _context.HinhAnhPhongs
                .Where(h => h.MaPhong == maPhong)
                .Select(h => new HinhAnhPhongVM
                {
                    path = h.path,
                    isUsed = h.isUsed,
                    MaPhong = h.MaPhong
                })
                .ToList();

            return images;
        }

        public JsonResult DeleteImage(int id)
        {
            var image = _context.HinhAnhPhongs.FirstOrDefault(h => h.IdHinhAnh == id);
            if (image == null)
            {
                return new JsonResult("Không tìm thấy ảnh")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Xóa file vật lý
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.path);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            // Xóa record trong database
            _context.HinhAnhPhongs.Remove(image);
            _context.SaveChanges();

            return new JsonResult("Xóa ảnh thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult SetAvatar(int id)
        {
            var image = _context.HinhAnhPhongs.FirstOrDefault(h => h.IdHinhAnh == id);
            if (image == null)
            {
                return new JsonResult("Không tìm thấy ảnh")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Reset tất cả ảnh của phòng về false
            var roomImages = _context.HinhAnhPhongs.Where(h => h.MaPhong == image.MaPhong);
            foreach (var roomImage in roomImages)
            {
                roomImage.isUsed = false;
            }

            // Set ảnh được chọn làm avatar
            image.isUsed = true;
            _context.SaveChanges();

            return new JsonResult("Đặt ảnh đại diện thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult UpdateImage(int id, UpdateHinhAnh model)
        {
            var image = _context.HinhAnhPhongs.FirstOrDefault(h => h.IdHinhAnh == id);
            if (image == null)
            {
                return new JsonResult("Không tìm thấy ảnh")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            image.path = model.path;
            image.isUsed = model.isUsed;
            _context.SaveChanges();

            return new JsonResult("Cập nhật ảnh thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}