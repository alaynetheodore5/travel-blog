using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Models
{
    public class ContactInquiry
    {
        [Key]
        public int ContactInquiryId { get;set; }

        [Required(ErrorMessage="Your name is required")]
        [MinLength(2,ErrorMessage="Name must be at least 2 characters")]
        public string ContactName { get;set; }

        [Required(ErrorMessage="Your email is required")]
        [EmailAddress(ErrorMessage="Please enter a valid Email address")]
        public string ContactEmail { get;set; }

        [Required(ErrorMessage="Subject is required")]
        [MinLength(5,ErrorMessage="Subject must be at least 5 characters")]
        public string ContactSubject { get; set; }

        [Required(ErrorMessage="Your message is required")]
        [MinLength(10,ErrorMessage="Message be at least 10 characters")]
        public string ContactMessage { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}