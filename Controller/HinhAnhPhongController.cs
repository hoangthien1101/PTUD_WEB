using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApi.ViewModel;
using MyWebApi.Model;
using webAPI.Data;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhAnhPhongController : ControllerBase
    {
        private readonly IHinhAnhPhongService _hinhAnhPhongService;

        public HinhAnhPhongController(IHinhAnhPhongService hinhAnhPhongService)
        {
            _hinhAnhPhongService = hinhAnhPhongService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]List<IFormFile> files, int MaPhong, bool isUsed)
        {
            try
            {
                var result = await _hinhAnhPhongService.WriteFileAsync(files, MaPhong, isUsed, "Phong");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{*path}")]
        public IActionResult GetImage(string path)
        {
            try
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path);
                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound("Không tìm thấy ảnh");
                }

                var image = System.IO.File.OpenRead(fullPath);
                return File(image, "image/jpeg");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("phong/{maPhong}")]
        public IActionResult GetImagesByPhong(int maPhong)
        {
            try
            {
                var images = _hinhAnhPhongService.GetImagesByPhong(maPhong);
                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteImage(int id)
        {
            try
            {
                var result = _hinhAnhPhongService.DeleteImage(id);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("set-avatar/{id}")]
        public IActionResult SetAvatar(int id)
        {
            try
            {
                var result = _hinhAnhPhongService.SetAvatar(id);
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateImage(int id, [FromForm] UpdateHinhAnh updateHinhAnh)
        {
            var update = _hinhAnhPhongService.UpdateImage(id, updateHinhAnh);
            return Ok(update);
        }
    }
}