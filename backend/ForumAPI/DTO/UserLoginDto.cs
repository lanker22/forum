using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
    public class UserLoginDto
    {
        [ProtectedPersonalData]
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [ProtectedPersonalData]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType("Password")]
        public string Password { get; set; }
    }
}
