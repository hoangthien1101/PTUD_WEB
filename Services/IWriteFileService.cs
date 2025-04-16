using webAPI.Data;

namespace MyWebApi.Service
{
    public interface IWriteFileRepository
    {
        Task<List<string>> WriteFileAsync(List<IFormFile> files, string folderName);
    }
    public class WriteFileRepository : IWriteFileRepository
    {
        private readonly AppDbContext _context;
        public WriteFileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<string>> WriteFileAsync(List<IFormFile> files, string folderName)
        {
            var urls = new List<string>();
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            
            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                {
                    continue;
                }

                var uniqueFileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                urls.Add($"uploads/{uniqueFileName}");
            }
            return urls;
        }
    }
}
