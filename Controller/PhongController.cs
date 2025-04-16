using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PhongController : ControllerBase
    {
        private readonly IPhongRepo _phongRepo;

        public PhongController(IPhongRepo phongRepo)
        {
            _phongRepo = phongRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var phong = _phongRepo.GetAll();
            return Ok(phong);
        }

        [HttpGet("GetBySoPhong/{SoPhong}")]
        public JsonResult GetBySoPhong(string SoPhong)
        {
            var phong = _phongRepo.GetBySoPhong(SoPhong);
            return phong;
        }

        [HttpPost("Create")]
        public async Task<JsonResult>Create([FromForm]AddPhong addPhong)
        {
            var phong = await _phongRepo.Create(addPhong);
            return phong;
        }

        [HttpPut("Update/{SoPhong}")]
        public JsonResult Update(string SoPhong, [FromForm]UpdatePhong updatePhong)
        {
            var phong = _phongRepo.Update(SoPhong, updatePhong);
            return phong;
        }

        [HttpDelete("Delete/{SoPhong}")]
        public JsonResult Delete(string SoPhong)
        {
            var phong = _phongRepo.Delete(SoPhong);
            return phong;
        }
        
    }   
}

