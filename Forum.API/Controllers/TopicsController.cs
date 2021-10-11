using Forum.BL.DTOs.Topics;
using Forum.BL.Services.Topics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        ITopicService _topicService;
        public TopicsController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<TopicDTO> AddNewTopic(CreateTopicDTO createTopicDTO)
        {
            return await _topicService.AddNewTopic(createTopicDTO);
        }
        [HttpGet("{topicID}")]
        public async Task<TopicDTO> GetTopicByID(long topicID)
        {
            return await _topicService.GetTopicByID(topicID);
        }

        [HttpGet]
        public async Task<List<TopicDTO>> AllTopics()
        {
            return await _topicService.AllTopics();
        }
        [HttpPost("{userID,topicID}")]
        public async Task<bool> AddNewUserToTopic(int userID,long topicID)
        {
            return await _topicService.AddNewUserToTopic(userID, topicID);
        }
        [HttpDelete("{userID,topicID}")]
        public async Task<bool> RemoveUserFromTopic(int userID,long topicID)
        {
            return await _topicService.RemoveUserFromTopic(userID,topicID);
        }

        [HttpDelete("{deletedBy,topicID}")]
        public async Task<bool> DeleteTopicByID(int deletedBy,long topicID)
        {
            return await _topicService.DeleteTopicByID(deletedBy, topicID);
        }

    }
}
