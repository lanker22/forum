using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("api/users/")]
    public class UserController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(ITokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _tokenService.IsValidUsernameAndPassword(userLoginDto.Username, userLoginDto.Password);
            if(result == false)
            {
                return BadRequest("Invalid login attempt");
            }
            else
            {
                var options = new CookieOptions();
                options.HttpOnly = true;

                var token = await _tokenService.GenerateToken(userLoginDto.Username);
                Response.Cookies.Append("jwt", token.access_token, options);
                return StatusCode(200, userLoginDto.Username);
            }
        }
        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            var options = new CookieOptions();
            options.Expires = DateTimeOffset.FromUnixTimeMilliseconds(-10);

            Response.Cookies.Append("jwt", "", options);
            return Ok("Success! Logged out");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var result = await _userManager.ChangePasswordAsync(
                user,
                changePasswordDto.OldPassword,
                changePasswordDto.NewPassword
                );
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("verify")]
        public async Task<IActionResult> VerifyUser()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return StatusCode(StatusCodes.Status200OK, user);
        }
    }
}
