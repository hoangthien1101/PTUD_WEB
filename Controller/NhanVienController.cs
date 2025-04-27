using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienRepo _nhanVienRepo;

        public NhanVienController(INhanVienRepo nhanVienRepo)
        {
            _nhanVienRepo = nhanVienRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            var nhanViens = _nhanVienRepo.GetAll(paginationParams);
            return Ok(nhanViens);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var nhanVien = _nhanVienRepo.GetById(id);
            return Ok(nhanVien);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddNV(NhanVienVM nhanVienVM)
        {
            var nhanVien = await _nhanVienRepo.AddNV(nhanVienVM);
            return Ok(nhanVien);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, NhanVienVM nhanVienVM)
        {
            var nhanVien = _nhanVienRepo.Update(id, nhanVienVM);
            return Ok(nhanVien);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var nhanVien = _nhanVienRepo.Delete(id);
            return Ok(nhanVien);
        }
    }
}