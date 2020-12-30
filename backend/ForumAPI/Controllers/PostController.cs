using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authentication;
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
    [Authorize]
    [ApiController]
    [Route("api/post/")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(IPostService postService, 
                              IMapper mapper, 
                              UserManager<ApplicationUser> userManager
                              )
        {
            _postService = postService;
            _mapper = mapper;
            _userManager = userManager;
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
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            postToCreate.ApplicationUser = user;
            try
            {
                await _postService.AddPostToDatabase(postToCreate);
                var postReadDto = _mapper.Map<PostReadDto>(postToCreate);
                return CreatedAtRoute("NewPostMethod", new { postReadDto.PostId }, postReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        [HttpPut("like/{id}")]
        public async Task<IActionResult> LikePost(int id)
        {
            try
            {
                var postToLike = await _postService.LikePost(id);
                return Ok(postToLike);
            }            
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
    
