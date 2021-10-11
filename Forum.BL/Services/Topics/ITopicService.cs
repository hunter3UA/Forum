using Forum.BL.DTOs.Topics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.BL.Services.Topics
{
    public interface ITopicService
    {
        Task<TopicDTO> AddNewTopic(CreateTopicDTO createTopicDTO);
        Task<TopicDTO> GetTopicByID(long topicDTO);
        Task<List<TopicDTO>> AllTopics();

        Task<bool> AddNewUserToTopic(int userID, long topicID);
        Task<bool> RemoveUserFromTopic(int userID, long topicID);
        Task<bool> DeleteTopicByID(int deletedBy, long topicID);
    }
}
