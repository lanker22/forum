using ForumAPI.Data;
using ForumAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            if (thread == null)
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
            if (threadToDelete == null)
            {
                throw new Exception("Thread does not exist");
            }
            else
            {
                _context.Threads.Remove(threadToDelete);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Post>> GetAllPostsInThread(int id)
        {
            var thread = await GetThreadById(id);
            return thread.Posts.ToList();
        }

        public List<Thread> GetAllThreads()
        {
            var threads = _context.Threads
                .Include(t => t.Posts).ThenInclude(p => p.ApplicationUser)
                .Include(t => t.ApplicationUser)
                .ToList();

            return threads;
        }

        public async Task<Thread> GetThreadById(int id)
        {
            var threadFound = await _context.Threads
                .Include(t => t.ApplicationUser)
                .Include(t => t.Posts).ThenInclude(p => p.ApplicationUser)
                .Include(t => t.Posts).ThenInclude(p => p.Likes).ThenInclude(l => l.ApplicationUser)
                .AsSplitQuery()
                .FirstOrDefaultAsync(i => i.ThreadId == id);

            if (threadFound == null)
            {
                throw new Exception("No thread found");
            }
            else
            {
                return threadFound;
            }
        }

        public List<Thread> SortThreadsByReplies()
        {
            return GetAllThreads().OrderByDescending(x => x.Posts.Count).ToList();
        }

        public List<Thread> GetThreadsWithNoReplies()
        {
            var threadsWithNoReplies = GetAllThreads().Where(x => x.Posts.Count == 1).ToList();
            return threadsWithNoReplies;
        }

        public List<Thread> SortThreadsByMostRecentPost()
        {
            var threads = GetAllThreads()
                .OrderByDescending(x => x.Posts.Max(x => x.TimePosted))
                .ToList();

            return threads;
        }
    }
}