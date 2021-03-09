using Microsoft.AspNetCore.Identity;
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

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}