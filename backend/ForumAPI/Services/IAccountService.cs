using ForumAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IAccountService
    {
        Task Register(UserCreateDto userCreateDto);

        Task Delete(int userId);
    }
}
