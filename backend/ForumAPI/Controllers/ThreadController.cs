using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("api/thread/")]
    public class ThreadController : Controller
    {
        private readonly IThreadService _threadService;
        private readonly IMapper _mapper;
        
        public ThreadController(IThreadService threadService, IMapper mapper)
        {
            _threadService = threadService;
            _mapper = mapper;
        }

        [HttpPost("create", Name="AddThread")]
        public async Task<IActionResult> CreateThread(ThreadCreateDto threadCreateDto)
        {
            try
            {
                var threadToAdd = _mapper.Map<Thread>(threadCreateDto);
                await _threadService.AddThreadToDatabase(threadToAdd);
                var threadReadDto = _mapper.Map<ThreadReadDto>(threadToAdd);
                return CreatedAtRoute("AddThread", new { threadReadDto.ThreadId }, threadReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
