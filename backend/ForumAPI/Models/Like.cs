using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        public Post Post { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
