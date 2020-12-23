using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        private readonly TokenService _tokenService;
        public PostController(IPostService postService, 
                              IMapper mapper, 
                              UserManager<ApplicationUser> userManager, 
                              TokenService tokenService)
        {
            _postService = postService;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await Task.Run(() => _postService.DeletePost(id));
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost(Name="NewPost")]
        [Route("new")]
        public async Task<IActionResult> CreatePost(PostCreateDto postCreateDto)
        {
            // access JWT token from request
            var jwt = await HttpContext.GetTokenAsync("jwt");

            // parse the token to get the payload data
            var tokenData = _tokenService.ParseToken(jwt);

            var user = tokenData.Claims.ToList();
            
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            
            try
            {
                await Task.Run(() => _postService.CreatePost(postToCreate));
                var postReadDto = _mapper.Map<PostReadDto>(postToCreate);
                return CreatedAtRoute("NewPost", new { postReadDto.PostId }, postReadDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("editpost/{id}")]
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
                    await Task.Run(() => _postService.UpdatePost(postToUpdate));
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
    
