using MyWebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using MyWebApi.Service;
using Microsoft.Extensions.Configuration;
using MyWebApi.Helper;

namespace MyWebApi.Services
{
    public interface IForgotPasswordService
    {
        Task<JsonResult> ForgotPassword(ForgotPasswordRequest request);
        Task<JsonResult> ResetPassword(ResetPasswordRequest request);
    }

    public class ForgotPasswordService : IForgotPasswordService
    {
        private readonly AppDbContext _context;
        private readonly ISendMailService _sendMailService;
        private readonly IConfiguration _configuration;
        private static Dictionary<string, (string Token, DateTime Expires)> _resetTokens = new Dictionary<string, (string Token, DateTime Expires)>();

        public ForgotPasswordService(AppDbContext context, ISendMailService sendMailService, IConfiguration configuration)
        {
            _context = context;
            _sendMailService = sendMailService;
            _configuration = configuration;
        }

        private string GenerateToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<JsonResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = _context.TaiKhoans.FirstOrDefault(u => u.Email == request.Email);
            if (user == null)
            {
                return new JsonResult("Email không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Tạo mã xác thực ngẫu nhiên 6 ký tự
            var token = GenerateToken();
            var expires = DateTime.Now.AddMinutes(15); // Token hết hạn sau 15 phút
            
            // Lưu token vào bộ nhớ tạm thời
            _resetTokens[request.Email] = (token, expires);

            // Gửi email chứa mã xác thực
            var emailContent = new EmailModel
            {
                FromEmail = _configuration["Gmail:Username"],
                ToEmail = request.Email,
                Subject = "Mã xác thực đặt lại mật khẩu",
                Body = $"Mã xác thực của bạn là: {token}\nMã này sẽ hết hạn sau 15 phút."
            };

            await _sendMailService.SendEmail(emailContent);

            return new JsonResult("Vui lòng kiểm tra email để lấy mã xác thực")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public async Task<JsonResult> ResetPassword(ResetPasswordRequest request)
        {
            // Tìm email tương ứng với token
            var email = _resetTokens.FirstOrDefault(x => x.Value.Token == request.ResetToken).Key;
            if (string.IsNullOrEmpty(email))
            {
                return new JsonResult("Mã xác thực không hợp lệ")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            // Kiểm tra token có hết hạn không
            if (!_resetTokens.TryGetValue(email, out var tokenInfo) || tokenInfo.Expires < DateTime.Now)
            {
                return new JsonResult("Mã xác thực đã hết hạn")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            var user = _context.TaiKhoans.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return new JsonResult("Email không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }

            // Cập nhật mật khẩu mới
            user.MatKhau = PasswordHasher.HashPassword(request.Password);
            await _context.SaveChangesAsync();

            // Xóa token sau khi đã sử dụng
            _resetTokens.Remove(email);

            return new JsonResult("Đặt lại mật khẩu thành công")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
} 