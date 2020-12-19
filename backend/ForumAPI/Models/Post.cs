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
        public ICollection<Post> Replies { get; set; }
        public ApplicationUser User { get; set; }

        public string Content { get; set; }

        public DateTime TimePosted { get; set; }
        
        [ForeignKey("User")]
        public int Id { get; set; }

    }
}
