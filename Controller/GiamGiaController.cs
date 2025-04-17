using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        private readonly IGiamGiaRepo _giamGiaRepo;

        public GiamGiaController(IGiamGiaRepo giamGiaRepo)
        {
            _giamGiaRepo = giamGiaRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_giamGiaRepo.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_giamGiaRepo.GetById(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddGG(GiamGiaVM giamGiaVM)
        {
            return Ok(await _giamGiaRepo.AddGG(giamGiaVM));
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, GiamGiaVM giamGiaVM)
        {
            return Ok(_giamGiaRepo.Update(id, giamGiaVM));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_giamGiaRepo.Delete(id));
        }
    }
}