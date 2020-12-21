using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public class ThreadService : IThreadService
    {
        public void CreateThread(Thread thread)
        {
            throw new NotImplementedException();
        }

        public void DeleteThread(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllPostsInThread(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Thread> GetAllThreads()
        {
            throw new NotImplementedException();
        }

        public Thread GetThreadById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
