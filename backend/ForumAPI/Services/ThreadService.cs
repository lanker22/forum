using ForumAPI.Data;
using ForumAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public class ThreadService : IThreadService
    {
        private readonly BaseDbContext _context;
        public ThreadService(BaseDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddThreadToDatabase(Thread thread)
        {
            if(thread == null)
            {
                throw new ArgumentNullException(nameof(thread));
            }
            else
            {
                await _context.Threads.AddAsync(thread);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> RemoveThreadFromDatabase(int id)
        {
            var threadToDelete = await GetThreadById(id);
            if(threadToDelete == null)
            {
                throw new Exception("Thread does not exist");
            }
            else
            {
                _context.Threads.Remove(threadToDelete);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Post>> GetAllPostsInThread(int id)
        {
            var thread = await GetThreadById(id);
            return thread.Posts;
        }

        public IEnumerable<Thread> GetAllThreads()
        {
            return _context.Threads;
        }

        public async Task<Thread> GetThreadById(int id)
        {
            var threadFound = await _context.Threads.FindAsync(id);
            if(threadFound == null)
            {
                throw new Exception("No thread found");
            }
            else
            {
                return threadFound;
            }
        }

        public IEnumerable<Thread> SortThreadsByReplies()
        {
            return _context.Threads.OrderByDescending(x => x.Posts.Count);
        }

        public IEnumerable<Thread> GetThreadsWithNoReplies()
        {
            var thread = _context.Threads.Where(x => x.Posts.Count == 0);
            if(thread == null)
            {
                throw new Exception("Thread does not exist");
            }
            else
            {
                return thread;
            }
        }
    }
}
