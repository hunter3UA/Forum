using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Forum.Core.Entities
{
    [Index(nameof(TopicName),IsUnique =true)]
    public class Topic
    {
        [Key]
        public long TopicID { get; set; }
        [Required]
        public string TopicName { get; set; }
        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string Description { get; set; }   
        [Required]
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; } = new List<User>();
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
