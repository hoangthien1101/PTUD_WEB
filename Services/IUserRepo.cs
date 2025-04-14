using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using MyWebApi.Data;
using webAPI.Data;
using MyWebApi.Helper;

namespace MyWebApi.Services
{
    public interface IUserRepo
    {
        List<UserVM> GetAll();
        Task<JsonResult> AddUser(AddUser uservm);
        LoginVM CheckUser(string check);
    }

    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<UserVM> GetAll()
        {
            var users = _context.TaiKhoans.Select(u => new UserVM
            {
                MaTK = u.MaTK,
                TenTK = u.TenTK,
                HinhAnh = u.HinhAnh,
                TenHienThi = u.TenHienThi,
                Phone = u.Phone,
                Email = u.Email,
                IsVerified = u.IsVerified,
                CreateAt = u.CreateAt,
                Xoa = u.Xoa,
                LoaiTK = u.VaiTro.MaLoai
            }).ToList();
            return users;
        }
        public LoginVM CheckUser(string? check = null)
        {
            var user = _context.TaiKhoans.Include(c => c.VaiTro).FirstOrDefault(c => c.TenTK == check || c.Email == check);
            if (user != null)
            {
                var _user = new LoginVM
                {
                    MaTK = user.MaTK,
                    TenTK = user.TenTK,
                    MatKhau = user.MatKhau,
                    TenLoai = user.VaiTro.TenLoai,
                };
               
                return _user;
            }
            return null;
        }
        public async Task<JsonResult> AddUser(AddUser uservm)
        {
            if(CheckUser(uservm.TenTK) == null)
            {
                //string pass = PasswordHasher.GetRandomPassword();
                var user = new TaiKhoan
                {
                    MaTK = uservm.MaTK,
                    TenTK = uservm.TenTK,
                    MatKhau = PasswordHasher.HashPassword(uservm.MatKhau),
                    TenHienThi = uservm.TenHienThi,
                    Email = uservm.Email,
                    Phone = uservm.Phone,
                    CreateAt = DateTime.Now,
                    LoaiTK = uservm.LoaiTK,
                };
                _context.TaiKhoans.Add(user);
                await _context.SaveChangesAsync();
                return new JsonResult("Thêm tài khoản thành công")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            return new JsonResult("Tài khoản đã tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}