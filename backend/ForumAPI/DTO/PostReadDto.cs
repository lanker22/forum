using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ForumAPI.Models;

namespace ForumAPI.DTO
{
    public class PostReadDto
    {
        [Required]
        public int PostId { get; set; }
        
        [Required]
        public List<string> Replies { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime TimePosted { get; set; }
    }
}
