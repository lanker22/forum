using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ForumAPI.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> BanUser(string userId)
        {
            var userToBan = await _userManager.FindByIdAsync(userId);
            if(userToBan == null)
            {
                throw new Exception("User doesn't exist");
            }
            else
            {
                userToBan.IsBanned = true;
                return await _userManager.UpdateAsync(userToBan);
            }
        }

        public void RemoveThread(int threadId)
        {
            throw new NotImplementedException();
        }
    }
}
