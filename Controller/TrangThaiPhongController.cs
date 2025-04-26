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
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            var trangThaiPhong = _trangThaiPhongRepo.GetAll(paginationParams);
            return Ok(trangThaiPhong);
        }

        [HttpGet("GetByMaTT/{MaTT}")]
        public IActionResult GetByMaTT(int MaTT)
        {
            var trangThaiPhong = _trangThaiPhongRepo.GetByMaTT(MaTT);
            return Ok(trangThaiPhong);
        }

        [HttpPost("Create")]
        public JsonResult Create([FromForm] AddTrangThaiPhong addTrangThaiPhong)
        {
            return _trangThaiPhongRepo.Create(addTrangThaiPhong);
        }
        
        [HttpPut("Update/{id}")]
        public JsonResult Update(int id, [FromForm] UpdateTrangThaiPhong updateTrangThaiPhong)
        {
            return _trangThaiPhongRepo.Update(id, updateTrangThaiPhong);
        }

        [HttpDelete("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            return _trangThaiPhongRepo.Delete(id);
        }
    }
}