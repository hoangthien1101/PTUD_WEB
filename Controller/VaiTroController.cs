using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VaiTroController : ControllerBase
    {
        private readonly IVaiTroRepo _vaiTroRepo;

        public VaiTroController(IVaiTroRepo vaiTroRepo)
        {
            _vaiTroRepo = vaiTroRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var vaiTro = _vaiTroRepo.GetAll();
            return Ok(vaiTro);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var vaiTro = _vaiTroRepo.GetById(id);
            return Ok(vaiTro);
        }
    }
}   

