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
        public async Task Delete(string username)
        {
            if(username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var userToDelete = await _userManager.FindByNameAsync(username);
            if(userToDelete == null)
            {
                throw new Exception("User does not exist");
            }

            var result = await _userManager.DeleteAsync(userToDelete);
            if (!result.Succeeded)
            {
                throw new Exception("Deletion failed");
            }
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
                var password = userCreateDto.Password;
                var userToAdd = _mapper.Map<ApplicationUser>(userCreateDto);
                var result = await _userManager.CreateAsync(userToAdd, password);

                if (!result.Succeeded)
                {
                    throw new Exception("Password not strong enough");
                }
            }
        }
    }
}
