using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("api/thread/", Name = "ThreadController")]
    public class ThreadController : Controller
    {
        private readonly IThreadService _threadService;

        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ThreadController(IThreadService threadService, 
                                IMapper mapper, 
                                UserManager<ApplicationUser> userManager,
                                IPostService postService)
        {
            _threadService = threadService;
            _mapper = mapper;
            _userManager = userManager;
            _postService = postService;
        }

        [HttpGet("recent", Name = "GetMostRecentThreads")]
        public IActionResult GetAllThreadsByMostRecentPost()
        {
            var threads = _threadService.SortThreadsByMostRecentPost();
            
            // NOTE: PUT THIS INTO METHOD IN THREADSERVICE CLASS
            var threadsDisplay = threads.Select(x => _mapper.Map<ThreadReadDto>(x)).ToList();

            return Ok(threadsDisplay);
        }


        [HttpGet("popular", Name = "GetMostPopularThreads")]
        public IActionResult GetAllThreadsByPopularity()
        {
            var threads = _threadService.SortThreadsByReplies();

            // NOTE: PUT THIS INTO METHOD IN THREADSERVICE CLASS
            var threadsDisplay = threads.Select(x => _mapper.Map<ThreadReadDto>(x)).ToList();

            return Ok(threadsDisplay);
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

                // create opening post 
                var openingPostCreateDto = new PostCreateDto
                {
                    Content = threadCreateDto.OpeningPost,
                    TimePosted = threadCreateDto.TimeCreated
                };

                var openingPost = _mapper.Map<Post>(openingPostCreateDto);

                openingPost.Thread = threadToAdd;

                await _postService.AddPostToDatabase(openingPost, user);

                return GetAllThreadsByMostRecentPost();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
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
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}", Name ="GetThreadById")]
        public async Task<IActionResult> GetThread(int id)
        {
            try
            {
                var thread = await _threadService.GetThreadById(id);
                var threadReadDto = _mapper.Map<ThreadReadDto>(thread);
                return Ok(threadReadDto);
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("noreplies")]
        public IActionResult SortByNoReplies()
        {
            try
            {
                var threads = _threadService.GetThreadsWithNoReplies();
                var threadsToDisplay = threads.Select(x => _mapper.Map<ThreadReadDto>(x)).ToList();
                return Ok(threadsToDisplay);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
