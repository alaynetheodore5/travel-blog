using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage="Message is required")]
        [MinLength(2)]
        public string MContent { get; set; }

        public int UserId { get; set; }

        public User Creator { get; set; }

        public int PostId { get; set; }

        public Post PostMessage { get; set; }
        
        public List<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}