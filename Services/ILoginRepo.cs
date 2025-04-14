using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webAPI.Data;
using MyWebApi.Helper;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Services
{
    public interface ILoginRepo
    {
        JsonResult Login(string TenTK, string password);
    }
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly IUserRepo _userRepo;
        private readonly ILogger<LoginRepo> _logger;

        public LoginRepo(AppDbContext context, IConfiguration config, IUserRepo userRepo, ILogger<LoginRepo> logger)
        {
            _context = context;
            _config = config;
            _userRepo = userRepo;
            _logger = logger;
        }

        public JsonResult Login(string TenTK, string password)
        {
            var user = _userRepo.CheckUser(TenTK); // kiểm tra user có tồn tại hay ko

            if (user != null)
            {
                _logger.LogInformation("Đăng nhập user: {Username} - Id: {IdUser} - Role: {Role} - HashedPass: {HashedPass}",
                    user.TenTK, user.MaTK, user.TenLoai, user.MatKhau);
                    
                bool check = PasswordHasher.verifyPassword(password, user.MatKhau);
                if (check)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);

                    var tokenDesciptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.MaTK),
                            new Claim(ClaimTypes.Name, user.TenTK),
                            new Claim(ClaimTypes.Role, user.TenLoai),
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                    };
                    var token = tokenHandler.CreateToken(tokenDesciptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return new JsonResult(jwtToken)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("Mật khẩu không đúng")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            return new JsonResult("Tài khoản không tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
