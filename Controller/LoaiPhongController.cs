using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhongController : ControllerBase
    {
        private readonly ILoaiPhongRepo _loaiPhongRepo;
    

        public LoaiPhongController(ILoaiPhongRepo loaiPhongRepo)
        {
            _loaiPhongRepo = loaiPhongRepo;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var loaiPhong = _loaiPhongRepo.GetAll();
            return Ok(loaiPhong);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var loaiPhong = _loaiPhongRepo.GetById(id);
            return Ok(loaiPhong);
        }

        [HttpPost("Create")]
        public async Task<JsonResult>Create([FromForm]AddLoaiPhong addLoaiPhong)
        {
            var loaiPhong = await _loaiPhongRepo.Create(addLoaiPhong);
            return loaiPhong;
        }

        [HttpPut("Update/{id}")]
        public JsonResult Update(int id, [FromForm]UpdateLoaiPhong updateLoaiPhong)
        {
            var loaiPhong = _loaiPhongRepo.Update(id, updateLoaiPhong);
            return loaiPhong;
        }

        [HttpDelete("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            var loaiPhong = _loaiPhongRepo.Delete(id);
            return loaiPhong;
        }
    }
}