using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ThreadController(IThreadService threadService, 
                                IMapper mapper, 
                                UserManager<ApplicationUser> userManager)
        {
            _threadService = threadService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("create", Name="AddThread")]
        public async Task<IActionResult> CreateThread(ThreadCreateDto threadCreateDto)
        {
            try
            {
                // get current logged in user
                var user = await _userManager.GetUserAsync(HttpContext.User);

                var threadToAdd = _mapper.Map<Thread>(threadCreateDto);
                
                // set thread creator to current logged in user
                threadToAdd.ApplicationUser = user;

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

        [HttpPost("{id}/delete")]
        public async Task<IActionResult> DeleteThread(int id) 
        {
            try
            {
                await _threadService.RemoveThreadFromDatabase(id);
                return Ok("Thread deleted!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
