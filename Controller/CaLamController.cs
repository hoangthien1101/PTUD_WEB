using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaLamController : ControllerBase
    {
        private readonly ICaLamRepo _caLamRepo;

        public CaLamController(ICaLamRepo caLamRepo)
        {
            _caLamRepo = caLamRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            return Ok(_caLamRepo.GetAll(paginationParams));
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_caLamRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddCaLam(CaLamVM caLamVM)
        {
            return Ok(await _caLamRepo.AddCaLam(caLamVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CaLamVM caLamVM)
        {
            return Ok(_caLamRepo.Update(id, caLamVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_caLamRepo.Delete(id));
        }
    }
}