using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO.User
{
    public class UserLoginDto
    {
        [ProtectedPersonalData]
        [Required]
        public string Username { get; set; }

        [ProtectedPersonalData]
        [Required]
        [DataType("Password")]
        public string Password { get; set; }
    }
}
