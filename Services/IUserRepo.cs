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
        JsonResult EditUser(string TenTK, EditUser edituser);
        JsonResult DeleteUser(string TenTK);
        JsonResult RegisterUser(RegisterUser registerUser);

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
            if (CheckUser(uservm.TenTK) == null)
            {
                if (string.IsNullOrEmpty(uservm.MatKhau))
                {
                    return new JsonResult("Mật khẩu không được để trống")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                var user = new TaiKhoan
                {
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
        public JsonResult EditUser(string TenTK, EditUser edituser)
        {
            var user = _context.TaiKhoans.FirstOrDefault(c => c.TenTK == TenTK);
            if (user != null)
            {
                user.TenHienThi = edituser.TenHienThi;
                user.Phone = edituser.Phone;
                _context.SaveChanges();
                return new JsonResult("Cập nhật tài khoản thành công")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            return new JsonResult("Tài khoản không tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        public JsonResult DeleteUser(string TenTK)
        {
            var user = _context.TaiKhoans.SingleOrDefault(l => l.TenTK == TenTK);
            if (user == null)
            {
                return new JsonResult("Không có tài khoản cần xóa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            _context.TaiKhoans.Remove(user);
            _context.SaveChanges();

            return new JsonResult("Đã xóa")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }

        public JsonResult RegisterUser(RegisterUser registerUser)
        {
            var checkUser = _context.TaiKhoans.FirstOrDefault(c => c.TenTK == registerUser.TenTK);
            if (checkUser == null)
            {
                if (string.IsNullOrEmpty(registerUser.MatKhau))
                {
                    return new JsonResult("Mật khẩu không được để trống")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }

                if (registerUser.MatKhau == registerUser.ReMatKhau)
                {
                    var newUser = new TaiKhoan
                    {
                        MaTK = registerUser.MaTK,
                        TenTK = registerUser.TenTK,
                        MatKhau = PasswordHasher.HashPassword(registerUser.MatKhau),
                        TenHienThi = registerUser.TenHienThi,
                        Email = registerUser.Email,
                        Phone = registerUser.Phone,
                        CreateAt = DateTime.Now,
                        LoaiTK = 2,
                    };
                    _context.TaiKhoans.Add(newUser);
                    _context.SaveChanges();
                    return new JsonResult("Đăng ký tài khoản thành công")
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new JsonResult("Mật khẩu không khớp")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
            }
            return new JsonResult("Tài khoản đã tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}