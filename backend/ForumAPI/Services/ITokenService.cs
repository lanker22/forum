using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface ITokenService
    {
        Task<bool> IsValidUsernameAndPassword(string username, string password);

        Task<dynamic> GenerateToken(string username);
    }
}
