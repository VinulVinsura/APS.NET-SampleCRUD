using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCRUD.Model;
using SampleCRUD.Service;

namespace SampleCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private UserService _userService;
        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpPost("add-user")]
        public IActionResult addUser(User user)
        {
            Responce responce = _userService.addUser(user);
            if (responce.StatusCode == 0)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }

        [HttpPost("login")]
        public IActionResult login(LoginDto loginDto) {

            Responce responce = _userService.login(loginDto);
            if (responce.StatusCode == 0)
            {
                return Ok(responce);
            }

            return BadRequest(responce);
        }
    }
}
