using ForumAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Data
{
    public class ThreadDbContext : DbContext
    {
        public ThreadDbContext(DbContextOptions<ThreadDbContext> options) : base(options)
        {
        }
        public DbSet<Thread> Threads { get; set; }
    }
}
