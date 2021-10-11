using System;

namespace Forum.BL.DTOs.Topics
{
    public class CreateTopicDTO
    { 
        public string TopicName { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }

        
    }
}
