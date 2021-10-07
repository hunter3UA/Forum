using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.BL.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Required]
        public string TextMessage { get; set; }
        public File[] Files { get; set; }
        [Required]
        public Topic Topic { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; }
        [Required]
        public int MessageLevel { get; set; }
        public Message[] Answers { get; set; }
    }
}
