using ForumAPI.DTO;
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

        public List<string> Replies { get; set; }

        public string Content { get; set; }

        public DateTime TimePosted { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Thread")]
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }
    }
}
