using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumAPI.Models;

namespace ForumAPI.DTO
{
    public class ThreadReadDto
    {
        public int ThreadId { get; set; }

        public string Title { get; set; }
        
        public List<Post> Posts { get; set; }        
    }
}
