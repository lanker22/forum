using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
    public class ThreadCreateDto
    {
        public string Title { get; set; }

        public string OpeningPost {get; set;}
        public DateTime TimeCreated { get; set; }

        public int ThreadId { get; set; }
    }
}
