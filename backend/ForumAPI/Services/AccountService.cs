using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public Task Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task Register(UserCreateDto userCreateDto)
        {
            if(userCreateDto == null)
            {
                throw new ArgumentNullException(nameof(userCreateDto));
            }

            var desiredUserName = userCreateDto.Username;
            var user = await _userManager.FindByNameAsync(desiredUserName);
            
            if(user != null)
            {
                throw new Exception("User already exists");
            }
            else
            {
                var userToAdd = _mapper.Map<ApplicationUser>(userCreateDto);
                await _userManager.CreateAsync(userToAdd);
            }
        }
    }
}
