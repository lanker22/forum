using ForumAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Data
{
    public class BaseDbContext : IdentityDbContext<ApplicationUser>
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Thread> Threads { get; set; }

        public virtual DbSet<Like> Likes { get; set; }
    }
}
