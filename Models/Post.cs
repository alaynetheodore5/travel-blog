using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class Post
    {
        [Key]
        public int PostId { get;set; }


        [Required(ErrorMessage="Post title is required")]
        [MinLength(2,ErrorMessage="Post title must be at least 2 characters")]
        public string Title { get;set; }

        [Required(ErrorMessage="Content is required")]
        [MinLength(10,ErrorMessage="Content must be at least 10 characters")]
        public string Content { get; set; }

        [Required(ErrorMessage="Image Url is required")]
        public string ImgUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // This is the foreign key
        public int UserId { get; set; }

        // An activity can have only one user that adds it.
        public User Adder { get; set; }

        // many to many
        public List<Subscription> Likers { get; set; }

        public List<Message> PostConvo { get; set; }

    }
}