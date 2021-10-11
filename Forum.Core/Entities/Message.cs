using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Entities
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [Required]
        public string TextMessage { get; set; }
        public List<File> Files { get; set; } = new List<File>();
        [Required]
        public Topic Topic { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public DateTime PublishedAt { get; set; }
        [Required]
        public int MessageLevel { get; set; }
        public List<Message> Answers { get; set; } = new List<Message>();
    }
}
