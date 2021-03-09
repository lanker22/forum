using ForumAPI.Data;
using ForumAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddPostToDatabase(Post post, ApplicationUser user)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            else
            {
                post.ApplicationUser = user;

                await _context.Posts.AddAsync(post);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> GetPostById(int id)
        {
            var postFound = await _context.Posts
                .Include(p => p.ApplicationUser)
                .Include(p => p.Likes)
                .ThenInclude(l => l.ApplicationUser)
                .AsSplitQuery()
                .FirstOrDefaultAsync(i => i.PostId == id);

            return postFound;
        }

        public async Task<int> UpdatePostInDatabase(Post postToUpdate)
        {
            if (postToUpdate == null)
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
            if (postToDelete == null)
            {
                throw new ArgumentNullException(nameof(postToDelete));
            }
            else
            {
                _context.Posts.Remove(postToDelete);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<Post> LikePost(int id, ApplicationUser user)
        {
            var postToLike = await GetPostById(id);
            if (postToLike == null)
            {
                throw new Exception("Post does not exist");
            }
            else
            {
                if (!postToLike.Likes.Select(x => x.ApplicationUser).Contains(user))
                {
                    var like = new Like() { ApplicationUser = user, Post = postToLike };
                    await _context.Likes.AddAsync(like);
                }
                await _context.SaveChangesAsync();
                return postToLike;
            }
        }

        public List<Like> GetUsersThatHaveLikedPost(int id)
        {
            var likes = _context.Likes.Where(x => x.Post.PostId == id).ToList();
            return likes;
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }
    }
}