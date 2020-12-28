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
    
        public DateTime LastUpdated { get; set; }

        public int Replies { get; set; }

        public DateTime TimeCreated { get; set; }
        
        public List<PostReadDto> Posts { get; set; }        
    }
}
