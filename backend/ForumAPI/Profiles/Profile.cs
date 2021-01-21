using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ForumAPI.Data;
using ForumAPI.DTO;
using ForumAPI.Models;

namespace ForumAPI.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Post, PostReadDto>();
            CreateMap<PostCreateDto, Post>();
            CreateMap<PostUpdateDto, Post>();
            CreateMap<List<PostReadDto>, List<Post>>();
            CreateMap<UserLoginDto, ApplicationUser>();
            CreateMap<UserCreateDto, ApplicationUser>();
            CreateMap<ThreadReadDto, Thread>();
            CreateMap<ThreadCreateDto, Thread>();
            CreateMap<ThreadUpdateDto, Thread>();
            CreateMap<Thread, ThreadReadDto>(); 
            CreateMap<ApplicationUser, ApplicationUserReadDto>();
            CreateMap<Like, LikeReadDto>();
        }
    }
}
