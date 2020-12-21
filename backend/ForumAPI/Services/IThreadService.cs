using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IThreadService
    {
        IEnumerable<Thread> GetAllThreads();

        IEnumerable<Post> GetAllPostsInThread(int id);

        Thread GetThreadById(int id);

        void CreateThread(Thread thread);

        void DeleteThread(int id);
    }
}
