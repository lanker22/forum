using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;

namespace ForumAPI.Profiles
{
    public class ThreadsProfile : Profile
    {
        public ThreadsProfile()
        {
            CreateMap<Thread, ThreadReadDto>();
            CreateMap<ThreadCreateDto, Thread>();
            CreateMap<ThreadUpdateDto, Thread>();
        }
    }
}
