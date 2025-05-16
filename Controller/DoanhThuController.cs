using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;

namespace MyWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoanhThuController : ControllerBase
    {
        private readonly IDoanhThuRepo _doanhThuRepo;

        public DoanhThuController(IDoanhThuRepo doanhThuRepo)
        {
            _doanhThuRepo = doanhThuRepo;
        }

        [HttpGet("TongDoanhThu")]
        public IActionResult GetTongDoanhThu()
        {
            return Ok(_doanhThuRepo.GetTongDoanhThu());
        }

        [HttpGet("TheoNgay")]
        public IActionResult GetDoanhThuTheoNgay([FromQuery] DateTime ngay)
        {
            return Ok(_doanhThuRepo.GetDoanhThuTheoNgay(ngay));
        }

        [HttpGet("TheoThang")]
        public IActionResult GetDoanhThuTheoThang([FromQuery] int thang, [FromQuery] int nam)
        {
            return Ok(_doanhThuRepo.GetDoanhThuTheoThang(thang, nam));
        }

        [HttpGet("TheoNam")]
        public IActionResult GetDoanhThuTheoNam([FromQuery] int nam)
        {
            return Ok(_doanhThuRepo.GetDoanhThuTheoNam(nam));
        }
    }
} 