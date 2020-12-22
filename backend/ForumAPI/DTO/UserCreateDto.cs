﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
    public class UserCreateDto
    {
        [ProtectedPersonalData]
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType("Password")]
        public string Password { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType("Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
