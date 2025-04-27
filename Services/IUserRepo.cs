using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using MyWebApi.Data;
using webAPI.Data;
using MyWebApi.Helper;
using MyWebApi.Service;

namespace MyWebApi.Services
{
    public interface IUserRepo
    {
        PaginationModel<UserVM> GetAll(PaginationParams paginationParams);
        Task<JsonResult> AddUser(AddUser uservm);
        LoginVM CheckUser(string check);
        JsonResult EditUser(string TenTK, EditUser edituser);
        JsonResult DeleteUser(string TenTK);
        JsonResult RegisterUser(RegisterUser registerUser);
        JsonResult DoiMatKhau(string TenTK, DoiMatKhauVM doiMatKhauVM);
        JsonResult ResetPass(int MaTK);
    }

    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;
        private readonly ISendMailService _sendEmail;
        private readonly IConfiguration _configuration;

        public UserRepo(AppDbContext context, ISendMailService sendEmail, IConfiguration configuration)
        {
            _context = context;
            _sendEmail = sendEmail;
            _configuration = configuration;
        }

        public PaginationModel<UserVM> GetAll(PaginationParams paginationParams)
        {
            var query = _context.TaiKhoans.AsQueryable();
            int totalItems = query.Count();
            if (paginationParams != null)
            {
                query = query
                    .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                    .Take(paginationParams.PageSize);
            }
            var users = query.Select(u => new UserVM
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
            return new PaginationModel<UserVM>
            {
                Items = users,
                TotalItems = totalItems,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize
            };
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
                        TenTK = registerUser.TenTK,
                        MatKhau = PasswordHasher.HashPassword(registerUser.MatKhau),
                        TenHienThi = registerUser.TenHienThi,
                        Email = registerUser.Email,
                        Phone = registerUser.Phone,
                        CreateAt = DateTime.Now,
                        LoaiTK = 3,
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
        public JsonResult DoiMatKhau(string TenTK, DoiMatKhauVM doiMatKhauVM)
        {
            var user = _context.TaiKhoans.FirstOrDefault(c => c.TenTK == TenTK);
            if (user == null)
            {
                return new JsonResult("Tài khoản không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            if (PasswordHasher.verifyPassword(doiMatKhauVM.MatKhauCu, user.MatKhau))
            {
                if (doiMatKhauVM.MatKhauMoi == doiMatKhauVM.ReMatKhau)
                {
                    user.MatKhau = PasswordHasher.HashPassword(doiMatKhauVM.MatKhauMoi);
                    _context.SaveChanges();
                    return new JsonResult("Đổi mật khẩu thành công")
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
            return new JsonResult("Mật khẩu cũ không đúng")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
        public JsonResult ResetPass(int MaTK)
        {
            var check = _context.TaiKhoans.FirstOrDefault(u => u.MaTK == MaTK);
            if (check == null)
            {
                return new JsonResult("User không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                string password = PasswordHasher.GetRandomPassword();
                check.MatKhau = PasswordHasher.HashPassword(password);
                _context.SaveChanges();
                var email = new EmailModel
                {
                    FromEmail = _configuration["Gmail:Username"],
                    ToEmail = check.Email,
                    Subject = "Quản trị viên đã reset mật khẩu của bạn",
                    Body = "Thông tin đăng nhập: " +
                    "- Username: " + check.TenTK + "" +
                    "- Mật khẩu: " + password,
                };
                _sendEmail.SendEmail(email);
                return new JsonResult("Đã Reset")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }
    }
}