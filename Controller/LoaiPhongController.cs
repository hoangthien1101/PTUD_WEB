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
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            var loaiPhong = _loaiPhongRepo.GetAll(paginationParams);
            return Ok(loaiPhong);
        }

        [HttpGet("GetByMaLoai/{MaLoai}")]
        public IActionResult GetByMaLoai(int MaLoai)
        {
            var loaiPhong = _loaiPhongRepo.GetByMaLoai(MaLoai);
            return Ok(loaiPhong);
        }

        [HttpPost("Create")]
        public JsonResult Create([FromForm] AddLoaiPhong addLoaiPhong)
        {
            return _loaiPhongRepo.Create(addLoaiPhong);
        }

        [HttpPut("Update/{MaLoai}")]
        public JsonResult Update(int MaLoai, [FromForm] UpdateLoaiPhong updateLoaiPhong)
        {
            return _loaiPhongRepo.Update(MaLoai, updateLoaiPhong);
        }

        [HttpDelete("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            return _loaiPhongRepo.Delete(id);
        }
    }
}