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

        private readonly PostDbContext _context;

        public PostService(PostDbContext context)
        {
            _context = context;
        }
        public async void CreatePost(Post post)
        {
            if(post == null)
            {
                throw new ArgumentNullException(nameof(post));    
            }
            else
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
            }
        }

        public async void DeletePost(int id)
        {
            var postToDelete = await GetPostById(id);
            if(postToDelete == null)
            {
                throw new ArgumentNullException(nameof(postToDelete));
            } 
            else
            {
                _context.Posts.Remove(postToDelete);
                await _context.SaveChangesAsync();
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

        public async void ReplyToPost(int postToReplyToId, Post newPost)
        {
            var postToReplyTo = await GetPostById(postToReplyToId);

            if(postToReplyTo == null)
            {
                throw new ArgumentNullException(nameof(postToReplyTo));
            }
            else if(newPost == null)
            {
                throw new ArgumentNullException(nameof(newPost));
            }
            else
            {
                var postReplyChain = postToReplyTo.Replies;
                postReplyChain.Add(newPost.Content);
            }
        }

        public async void UpdatePost(Post postToUpdate)
        {
            if(postToUpdate == null)
            {
                throw new ArgumentNullException(nameof(postToUpdate));
            }
            else
            {
                _context.Posts.Update(postToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
