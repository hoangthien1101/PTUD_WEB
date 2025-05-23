using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;
using webAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PhongController : ControllerBase
    {
        private readonly IPhongRepo _phongRepo;
        private readonly AppDbContext _context;

        public PhongController(IPhongRepo phongRepo, AppDbContext context)
        {
            _phongRepo = phongRepo;
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            var result = _phongRepo.GetAll(paginationParams);
            return Ok(result);
        }

        [HttpGet("GetBySoPhong/{SoPhong}")]
        public JsonResult GetBySoPhong(string SoPhong)
        {
            var phong = _phongRepo.GetBySoPhong(SoPhong);
            return phong;
        }

        [HttpPost("Create")]
        public async Task<JsonResult>Create([FromForm]AddPhong addPhong, List<IFormFile> files)
        {
            var phong = await _phongRepo.Create(addPhong,files);
            return phong;
        }

        [HttpPut("Update/{SoPhong}")]
        public JsonResult Update(string SoPhong, [FromForm]UpdatePhong updatePhong)
        {
            var phong = _phongRepo.Update(SoPhong, updatePhong);
            return phong;
        }

        [HttpPut("Delete/{id}")]
        public JsonResult Delete(int id, DeletePhong deletePhong)
        {
            var phong = _phongRepo.Delete(id, deletePhong);
            return phong;
        }
        
    }   
}

