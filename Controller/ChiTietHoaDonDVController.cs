using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonDVController : ControllerBase
    {
        private readonly IChiTietHoaDonDVRepo _chiTietHoaDonDVRepo;

        public ChiTietHoaDonDVController(IChiTietHoaDonDVRepo chiTietHoaDonDVRepo)
        {
            _chiTietHoaDonDVRepo = chiTietHoaDonDVRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            return Ok(_chiTietHoaDonDVRepo.GetAll(paginationParams));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_chiTietHoaDonDVRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddCTHDDV(ChiTietHoaDonDVVM chiTietHoaDonDVVM)
        {
            return Ok(await _chiTietHoaDonDVRepo.AddCTHDDV(chiTietHoaDonDVVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ChiTietHoaDonDVVM chiTietHoaDonDVVM)
        {
            return Ok(_chiTietHoaDonDVRepo.Update(id, chiTietHoaDonDVVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_chiTietHoaDonDVRepo.Delete(id));
        }   
    }
}