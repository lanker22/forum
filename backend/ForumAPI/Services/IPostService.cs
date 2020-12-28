using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();

        Task<Post> GetPostById(int id); 
        
        Task<int> AddPostToDatabase(Post post);

        Task<int> UpdatePostInDatabase(Post post);

        Task<int> RemovePostFromDatabase(int id);

        Task<int> ReplyToPost(int id, Post newPost);

        Task<Post> LikePost(int id);
    }
}
