using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
        public class ChangePasswordDto
        {
            [ProtectedPersonalData]
            [Required(ErrorMessage = "Please enter your old password")]
            [DataType("Password")]
            public string OldPassword { get; set; }

            [ProtectedPersonalData]
            [Required(ErrorMessage = "Please enter your new password")]
            [DataType("Password")]
            public string NewPassword { get; set; }
        }
}
