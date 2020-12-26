using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.DTO
{
    public class ThreadUpdateDto
    {
        public int ThreadId { get; set; }

        public string UpdatedTitle { get; set; }
    }
}
