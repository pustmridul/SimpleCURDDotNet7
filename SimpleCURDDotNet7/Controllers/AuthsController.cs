using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCURDDotNet7.DTOs;
using SimpleCURDDotNet7.Interfaces;
using SimpleCURDDotNet7.Services;
using System.Security.Claims;

namespace SimpleCURDDotNet7.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginReq model)
        {
            if (model is null)
            {
                return BadRequest("Invalid client request");
            }
            return Ok(await _userService.UserLogin(model));
        }
        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh(TokenReq model)
        {
            if (model is null)
                return BadRequest("Invalid client request");

            return Ok(await _userService.Refresh(model));
        }


        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity?.Name??"";
            return Ok(await _userService.Revok(username));
        }
    }
}
