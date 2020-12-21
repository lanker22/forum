using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserLoginDto, ApplicationUser>();
        }
    }
}
