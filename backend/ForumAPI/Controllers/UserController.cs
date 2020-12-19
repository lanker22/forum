using ForumAPI.Models;
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

    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {

        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetUser(int userId)
        {

        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {

        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto useRegisterDto)
        {

        }

        [Route("deregister")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {

        }

    }
}
