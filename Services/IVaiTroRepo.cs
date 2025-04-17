using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.ViewModel;
using MyWebApi.Data;
using webAPI.Data;
using MyWebApi.Helper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MyWebApi.Services
{
    public interface IVaiTroRepo
    {
        List<VaiTroVM> GetAll();
        JsonResult GetById(int id);
        JsonResult Create(AddVaiTro addVaiTro);
        JsonResult Update(int idVaiTro, AddVaiTro addVaiTro);
        JsonResult Delete(int id);
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
            var vaiTroVM = new VaiTroVM
            {
                TenLoai = vaiTro.TenLoai
            };
            return new JsonResult(vaiTroVM)
            {
                StatusCode = StatusCodes.Status200OK
            };
        }   

        public JsonResult Create(AddVaiTro addVaiTro)
        {
            var vaiTro = _context.VaiTros.FirstOrDefault(v => v.TenLoai == addVaiTro.TenLoai);
            if (vaiTro != null)
            {
                return new JsonResult("Vai trò đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            var vaiTros = new VaiTro
            {   
                TenLoai = addVaiTro.TenLoai
            };
            _context.VaiTros.Add(vaiTros);
            _context.SaveChanges();
            return new JsonResult(vaiTros)
            {
                StatusCode = StatusCodes.Status201Created       
            };
        }

        public JsonResult Update(int idVaiTro, AddVaiTro addVaiTro)
        {
            var vaiTro = _context.VaiTros.FirstOrDefault(v => v.MaLoai == idVaiTro);    
            if (vaiTro == null)
            {
                return new JsonResult("Vai trò không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };  
            }
            vaiTro.TenLoai = addVaiTro.TenLoai;
            _context.SaveChanges();
            return new JsonResult(vaiTro)
            {
                StatusCode = StatusCodes.Status200OK    
            };
        }

        public JsonResult Delete(int id)
        {
            var vaiTro = _context.VaiTros.FirstOrDefault(v => v.MaLoai == id);  
            if (vaiTro == null)
            {
                return new JsonResult("Vai trò không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };  
            }
            _context.VaiTros.Remove(vaiTro);
            _context.SaveChanges();
            return new JsonResult("Vai trò đã được xóa")
            {
                StatusCode = StatusCodes.Status200OK    
            };
        }
    }
}
