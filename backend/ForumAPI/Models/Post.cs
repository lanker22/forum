using ForumAPI.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string Content { get; set; }

        public DateTime TimePosted { get; set; }

        public ICollection<Like> Likes { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Thread Thread { get; set; }
    }
}