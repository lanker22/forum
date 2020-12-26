using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IAdminService
    {
        Task<IdentityResult> BanUser(string userId);
    }
}
