using Microsoft.AspNetCore.Mvc;
using MyWebApi.Services;
using MyWebApi.ViewModel;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _loginRepo;
        private readonly IUserRepo _userRepo;
        public LoginController(ILoginRepo loginRepo, IUserRepo userRepo)
        {
            _loginRepo = loginRepo;
            _userRepo = userRepo;
        }
        [HttpPost]
        public IActionResult Login([FromForm] string TenTK, [FromForm] string password)
        {
            return _loginRepo.Login(TenTK, password);
        }
        // [HttpPost("Register")]
        // public IActionResult Register(AddUser user)
        // {
        //     var result = _userRepo.AddUser(user);
        //     return Ok(result);
        // }
    }
}