using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Services
{
    public interface IAdminService
    {
        void BanUser(int userId);

        void RemovePost(int postId);

        void RemoveThread(int threadId);
    }
}
