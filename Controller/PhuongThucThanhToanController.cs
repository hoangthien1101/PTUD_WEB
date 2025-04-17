using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongThucThanhToanController : ControllerBase
    {
        private readonly IPhuongThucThanhToanRepo _phuongThucThanhToanRepo;

        public PhuongThucThanhToanController(IPhuongThucThanhToanRepo phuongThucThanhToanRepo)
        {
            _phuongThucThanhToanRepo = phuongThucThanhToanRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_phuongThucThanhToanRepo.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_phuongThucThanhToanRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddPTTT(PhuongThucThanhToanVM phuongThucThanhToanVM)
        {
            var result = await _phuongThucThanhToanRepo.AddPTTT(phuongThucThanhToanVM);
            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, PhuongThucThanhToanVM phuongThucThanhToanVM)
        {
            return Ok(_phuongThucThanhToanRepo.Update(id, phuongThucThanhToanVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_phuongThucThanhToanRepo.Delete(id));
        }
    }
}