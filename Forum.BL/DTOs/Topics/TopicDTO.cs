using Forum.BL.DTOs.Users;
using System;

namespace Forum.BL.DTOs.Topics
{
    public class TopicDTO
    {
        public long TopicID { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public UserDTO[] Users { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
