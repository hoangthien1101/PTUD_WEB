using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Model;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll([FromQuery] PaginationParams paginationParams)
        {
            var users = _userRepo.GetAll(paginationParams);
            return Ok(users);
        }

        [HttpGet("check")]
        public IActionResult CheckUser(string check)
        {
            var user = _userRepo.CheckUser(check);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpPost("Create")]
        public async Task<JsonResult> AddUser([FromForm] AddUser uservm)
        {
            var result = await _userRepo.AddUser(uservm);
            return result;
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser([FromForm] RegisterUser registerUser)
        {
            return Ok(_userRepo.RegisterUser(registerUser));
        }


        [HttpPost("reset/{MaTK}")]
        public IActionResult ResetPassword(int MaTK)
        {
            var result = _userRepo.ResetPass(MaTK);
            return result;
        }

        [HttpPut("Update")]
        public IActionResult EditUser(string TenTK, EditUser edituser)
        {
            return Ok(_userRepo.EditUser(TenTK, edituser));
        }

        [HttpPut("DoiMatKhau/{TenTK}")]
        public IActionResult DoiMatKhau(string TenTK, DoiMatKhauVM doiMatKhauVM)
        {
            var result = _userRepo.DoiMatKhau(TenTK, doiMatKhauVM);
            return result;
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteUser(string TenTK)
        {
            return Ok(_userRepo.DeleteUser(TenTK));
        }
    }
}

