using Microsoft.AspNetCore.Mvc;
using MyWebApi.ViewModel;
using MyWebApi.Services;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatPhongController : ControllerBase
    {
        private readonly IDatPhongRepo _datPhongRepo;

        public DatPhongController(IDatPhongRepo datPhongRepo)
        {
            _datPhongRepo = datPhongRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var datPhongs = _datPhongRepo.GetAll();
            return Ok(datPhongs);
        }   

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var datPhong = _datPhongRepo.GetById(id);
            return Ok(datPhong);
        }

        [HttpPost("Create")]
        public IActionResult Create(AddDatPhong addDatPhong)
        {
            var datPhong = _datPhongRepo.Create(addDatPhong);
            return Ok(datPhong);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateDatPhong updateDatPhong)
        {
            var datPhong = _datPhongRepo.Update(id, updateDatPhong);
            return Ok(datPhong);
        }

        [HttpPut("Delete/{id}")]
        public IActionResult Delete(int id, DeleteDatPhong deleteDatPhong)
        {
            var datPhong = _datPhongRepo.Delete(id, deleteDatPhong);
            return Ok(datPhong);
        }
    }
}
