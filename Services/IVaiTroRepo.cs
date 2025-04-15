using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using MyWebApi.Data;
using webAPI.Data;
using MyWebApi.Helper;

namespace MyWebApi.Services
{
    public interface IVaiTroRepo
    {
        List<VaiTroVM> GetAll();
        JsonResult GetById(int id);
    }

    public class VaiTroRepo : IVaiTroRepo
    {
        private readonly AppDbContext _context;

        public VaiTroRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<VaiTroVM> GetAll()
        {
            return _context.VaiTros.Select(v => new VaiTroVM
            {
                TenLoai = v.TenLoai
            }).ToList();
        }

        public JsonResult GetById(int id)
        {
            var vaiTro = _context.VaiTros.Find(id);
            if (vaiTro == null)
            {
                return new JsonResult("Vai trò không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            var vaitro = new VaiTroVM {
                TenLoai = vaiTro.TenLoai
            };
            return new JsonResult(vaitro)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
