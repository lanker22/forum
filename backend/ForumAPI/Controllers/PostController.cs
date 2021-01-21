using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/post/")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IThreadService _threadService;
        public PostController(IPostService postService, 
                              IMapper mapper, 
                              UserManager<ApplicationUser> userManager,
                              IThreadService threadService
                              )
        {
            _postService = postService;
            _mapper = mapper;
            _userManager = userManager;
            _threadService = threadService;
        }

        [HttpGet("all")]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}", Name ="GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _postService.GetPostById(id);
                var postReadDto = _mapper.Map<PostReadDto>(post);
                return Ok(postReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.RemovePostFromDatabase(id);
                return Ok("Post deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("create", Name ="NewPostMethod")]
        public async Task<IActionResult> CreatePost(PostCreateDto postCreateDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var thread = await _threadService.GetThreadById(postCreateDto.ThreadId);
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            postToCreate.Thread = thread;

            try
            {
                await _postService.AddPostToDatabase(postToCreate, user);
                var threadReadDto = _mapper.Map<ThreadReadDto>(thread);
                return Ok(threadReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("editpost/{id}")]
        public async Task<IActionResult> EditPost(int id, PostUpdateDto postUpdateDto)
        {
            try
            {
                var postToUpdate = await _postService.GetPostById(id);
                if (postToUpdate == null)
                {
                    throw new ArgumentNullException("Invalid request");
                }
                else
                {
                    _mapper.Map(postUpdateDto, postToUpdate);
                    await _postService.UpdatePostInDatabase(postToUpdate);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("like/{id}")]
        public async Task<IActionResult> LikePost(int id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var post = await _postService.LikePost(id, user);
                var postReadDto = _mapper.Map<PostReadDto>(post);
                return Ok(postReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
    
