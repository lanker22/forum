﻿using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(TokenService tokenService, UserManager<ApplicationUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var result = await _tokenService.IsValidUsernameAndPassword(userLoginDto.Username, userLoginDto.Password);
            if(result == false)
            {
                return BadRequest("Invalid login attempt");
            }
            else
            {
                await _tokenService.GenerateToken(userLoginDto.Username);
                return Ok();
            }
        }

        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
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
    }
}
