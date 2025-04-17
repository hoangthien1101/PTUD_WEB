using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TrangThaiDatPhongController : ControllerBase
    {
        private readonly ITrangThaiDatPhongRepo _trangThaiDatPhongRepo;

        public TrangThaiDatPhongController(ITrangThaiDatPhongRepo trangThaiDatPhongRepo)
        {
            _trangThaiDatPhongRepo = trangThaiDatPhongRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var trangThaiDatPhong = _trangThaiDatPhongRepo.GetAll();
            return Ok(trangThaiDatPhong);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var trangThaiDatPhong = _trangThaiDatPhongRepo.GetById(id);
            return Ok(trangThaiDatPhong);
        }

        [HttpPost("Create")]
        public IActionResult Create(AddTrangThaiDatPhong addTrangThaiDatPhong)
        {
            var trangThaiDatPhong = _trangThaiDatPhongRepo.Create(addTrangThaiDatPhong);
            return Ok(trangThaiDatPhong);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateTrangThaiDatPhong updateTrangThaiDatPhong)
        {
            var trangThaiDatPhong = _trangThaiDatPhongRepo.Update(id, updateTrangThaiDatPhong);
            return Ok(trangThaiDatPhong);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var trangThaiDatPhong = _trangThaiDatPhongRepo.Delete(id);
            return Ok(trangThaiDatPhong);
        }
    }
}
