using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly IDichVuRepo _dichVuRepo;

        public DichVuController(IDichVuRepo dichVuRepo)
        {
            _dichVuRepo = dichVuRepo;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            return Ok(_dichVuRepo.GetAll(paginationParams));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_dichVuRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddDV(DichVuVM dichVuVM)
        {
            return Ok(await _dichVuRepo.AddDV(dichVuVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, DichVuVM dichVuVM)
        {
            return Ok(_dichVuRepo.Update(id, dichVuVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_dichVuRepo.Delete(id));
        }
        
    }
}