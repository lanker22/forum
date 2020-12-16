using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class Thread
    {
        [Key]
        public int ThreadId { get; set; }
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }
        public bool IsSticky { get; set; }
        public User User { get; set; }

        [ForeignKey("SubForum")]
        public int SubForumId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
