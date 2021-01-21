using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsBanned { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
