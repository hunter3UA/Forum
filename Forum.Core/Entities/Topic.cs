using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Entities
{
    public class  Topic
    {
        [Key]
        public long TopicID { get; set; }
        [Required]
        public string TopicName { get; set; }
        public User[] Users { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
