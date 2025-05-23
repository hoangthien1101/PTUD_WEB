using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuDungDichVuController : ControllerBase
    {
        private readonly ISuDungDichVuRepo _suDungDichVuRepo;

        public SuDungDichVuController(ISuDungDichVuRepo suDungDichVuRepo)
        {
            _suDungDichVuRepo = suDungDichVuRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            return Ok(_suDungDichVuRepo.GetAll(paginationParams));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_suDungDichVuRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddSDDV(SuDungDichVuVM suDungDichVuVM)
        {
            return Ok(await _suDungDichVuRepo.AddSDDV(suDungDichVuVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, SuDungDichVuVM suDungDichVuVM)
        {
            return Ok(_suDungDichVuRepo.Update(id, suDungDichVuVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_suDungDichVuRepo.Delete(id));
        }
    }       
}