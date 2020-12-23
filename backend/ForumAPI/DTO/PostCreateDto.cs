using ForumAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
    public class PostCreateDto
    {
        public string Content { get; set; }

        public DateTime TimePosted { get; set; }

        public ApplicationUser User{ get; set; }
        // public int ThreadId { get; set; }
    }
}
