using AutoMapper;
using ForumAPI.DTO;
using ForumAPI.Models;
using ForumAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("api/post/")]
    public class PostController : Controller
    {
        private readonly PostService _postService;
        private readonly IMapper _mapper;
        public PostController(PostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
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

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> CreatePost(PostCreateDto postCreateDto)
        {
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            try
            {
                await Task.Run(() => _postService.CreatePost(postToCreate));
                var postReadDto = _mapper.Map<PostReadDto>(postToCreate);
                return CreatedAtRoute("Get", new { postReadDto.Id }, postReadDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
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
    
