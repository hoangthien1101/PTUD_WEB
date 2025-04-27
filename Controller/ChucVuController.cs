using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepo _chucVuRepo;

        public ChucVuController(IChucVuRepo chucVuRepo)
        {
            _chucVuRepo = chucVuRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            return Ok(_chucVuRepo.GetAll(paginationParams));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_chucVuRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddCV(ChucVuVM chucVuVM)
        {
            return Ok(await _chucVuRepo.AddCV(chucVuVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, ChucVuVM chucVuVM)
        {
            return Ok(_chucVuRepo.Update(id, chucVuVM));
        }   

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_chucVuRepo.Delete(id));
        }   
    }
}