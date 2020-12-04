using System.ComponentModel.DataAnnotations;

namespace Travel.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        public int UserId  {get; set;}
        public int PostId { get; set; }

        public User PostLiker { get; set;}
        public Post ThisPost { get; set; }

    }
}