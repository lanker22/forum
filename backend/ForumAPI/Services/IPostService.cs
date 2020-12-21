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
        
        void CreatePost(Post post);

        void DeletePost(int id);

        void UpdatePost(Post post);

        void ReplyToPost(int id, Post newPost);
    }
}
