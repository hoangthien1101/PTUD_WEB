using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangThaiPhongController : ControllerBase
    {
        private readonly ITrangThaiPhongRepo _trangThaiPhongRepo;

        public TrangThaiPhongController(ITrangThaiPhongRepo trangThaiPhongRepo)
        {
            _trangThaiPhongRepo = trangThaiPhongRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var trangThaiPhong = _trangThaiPhongRepo.GetAll();
            return Ok(trangThaiPhong);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var trangThaiPhong = _trangThaiPhongRepo.GetById(id);
            return Ok(trangThaiPhong);
        }

        [HttpPost("Create")]
        public async Task<JsonResult> Create([FromForm]AddTrangThaiPhong addTrangThaiPhong)
        {
            var trangThaiPhong = await _trangThaiPhongRepo.Create(addTrangThaiPhong);
            return trangThaiPhong;
        }
        
        [HttpPut("Update/{id}")]
        public JsonResult Update(int id, [FromForm]UpdateTrangThaiPhong updateTrangThaiPhong)
        {
            var trangThaiPhong = _trangThaiPhongRepo.Update(id, updateTrangThaiPhong);
            return trangThaiPhong;
        }

        [HttpDelete("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var trangThaiPhong = _trangThaiPhongRepo.Delete(id);
            return trangThaiPhong;
        }
        
    }
}