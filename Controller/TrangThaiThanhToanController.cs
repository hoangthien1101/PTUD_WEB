using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrangThaiThanhToanController : ControllerBase
    {
        private readonly ITrangThaiThanhToanRepo _trangThaiThanhToanRepo;

        public TrangThaiThanhToanController(ITrangThaiThanhToanRepo trangThaiThanhToanRepo)
        {
            _trangThaiThanhToanRepo = trangThaiThanhToanRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var trangThaiThanhToan = _trangThaiThanhToanRepo.GetAll();
            return Ok(trangThaiThanhToan);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var trangThaiThanhToan = _trangThaiThanhToanRepo.GetById(id);
            return Ok(trangThaiThanhToan);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddTT(TrangThaiThanhToanVM trangThaiThanhToanVM)
        {
            var result = await _trangThaiThanhToanRepo.AddTT(trangThaiThanhToanVM);
            return result;
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, TrangThaiThanhToanVM trangThaiThanhToanVM)
        {
            var trangThaiThanhToan = _trangThaiThanhToanRepo.Update(id, trangThaiThanhToanVM);
            return Ok(trangThaiThanhToan);
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var trangThaiThanhToan = _trangThaiThanhToanRepo.Delete(id);
            return Ok(trangThaiThanhToan);
        }
        
        
    }
}