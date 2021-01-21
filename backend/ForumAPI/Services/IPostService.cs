using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();

        Task<Post> GetPostById(int id); 
        
        Task<int> AddPostToDatabase(Post post, ApplicationUser user);

        Task<int> UpdatePostInDatabase(Post post);

        Task<int> RemovePostFromDatabase(int id);

        Task<Post> LikePost(int id, ApplicationUser user);
    }
}
