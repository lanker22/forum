using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IThreadService
    {
        List<Thread> GetAllThreads();

        Task<List<Post>> GetAllPostsInThread(int id);

        Task<Thread> GetThreadById(int id);

        Task<int> AddThreadToDatabase(Thread thread);

        Task<int> RemoveThreadFromDatabase(int id);

        List<Thread> SortThreadsByReplies();

        List<Thread> GetThreadsWithNoReplies();

        List<Thread> SortThreadsByMostRecentPost();
    }
}
