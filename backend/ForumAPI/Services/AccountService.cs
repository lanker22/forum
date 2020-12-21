using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public class AccountService : IAccountService
    {
        public Task<IActionResult> Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Register()
        {
            throw new NotImplementedException();
        }
    }
}
