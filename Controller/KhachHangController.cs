using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangRepo _khachHangRepo;

        public KhachHangController(IKhachHangRepo khachHangRepo)
        {
            _khachHangRepo = khachHangRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var khachHangs = _khachHangRepo.GetAll();
            return Ok(khachHangs);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var khachHang = _khachHangRepo.GetById(id);
            return Ok(khachHang);
        }

        [HttpPost("Create")]
        public IActionResult Create(AddKhachHangVM khachHang)
        {
            var khachHangs = _khachHangRepo.Create(khachHang);
            return Ok(khachHangs);
        }
        
        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateKhachHang khachHang)
        {
           var khachHangs = _khachHangRepo.Update(id, khachHang);
            return Ok(khachHangs);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id , DeleteKhachHang khachHang)
        {
           var khachHangs = _khachHangRepo.Delete(id, khachHang);
            return Ok(khachHangs);
        }
        
    }
}
