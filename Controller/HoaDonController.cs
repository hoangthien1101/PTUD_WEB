using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepo _hoaDonRepo;

        public HoaDonController(IHoaDonRepo hoaDonRepo)
        {
            _hoaDonRepo = hoaDonRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_hoaDonRepo.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_hoaDonRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddHD(HoaDonVM hoaDonVM)
        {
            return Ok(await _hoaDonRepo.AddHD(hoaDonVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, HoaDonVM hoaDonVM)
        {
            return Ok(_hoaDonRepo.Update(id, hoaDonVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_hoaDonRepo.Delete(id));
        }
    }
}