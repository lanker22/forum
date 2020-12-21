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
        public bool IsSticky { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
