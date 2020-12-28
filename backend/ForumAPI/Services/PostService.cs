using ForumAPI.Data;
using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public class PostService : IPostService
    {

        private readonly BaseDbContext _context;

        public PostService(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddPostToDatabase(Post post)
        {
            if(post == null)
            {
                throw new ArgumentNullException(nameof(post));    
            }
            else
            {
                await _context.Posts.AddAsync(post);
                return await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public async Task<Post> GetPostById(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<int> UpdatePostInDatabase(Post postToUpdate)
        {
            if(postToUpdate == null)
            {
                throw new ArgumentNullException(nameof(postToUpdate));
            }
            else
            {
                _context.Posts.Update(postToUpdate);
                return await _context.SaveChangesAsync();
            }
        }
        public async Task<int> RemovePostFromDatabase(int id)
        {
            var postToDelete = await GetPostById(id);
            if(postToDelete == null)
            {
                throw new ArgumentNullException(nameof(postToDelete));
            } 
            else
            {
                _context.Posts.Remove(postToDelete);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ReplyToPost(int id, Post newPost)
        {
            var postToReplyTo = await GetPostById(id);
            if(postToReplyTo == null)
            {
                throw new Exception("Post does not exist");
            }
            else
            {
                _context.Posts.Update(newPost);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> LikePost(int id)
        {
            var postToLike = await GetPostById(id);
            if(postToLike == null)
            {
                throw new Exception("Post does not exist");
            }
            else
            {
                postToLike.Likes += 1;
                _context.Update(postToLike);
                await _context.SaveChangesAsync();
                return postToLike;
            }
        }
    }
}
