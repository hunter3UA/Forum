using AutoMapper;
using Forum.BL.DTOs.Topics;
using Forum.BL.Mapping;
using Forum.Core.Entities;
using Forum.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.BL.Services.Topics
{
    public class TopicService:ITopicService
    {
        IMapper _mapper;
        public TopicService()
        {
            _mapper = AutoMapperConfiguration.Configure().CreateMapper();
        }
        public async Task<TopicDTO> AddNewTopic(CreateTopicDTO createTopicDTO)
        {
            Topic newTopic = _mapper.Map<Topic>(createTopicDTO);
            newTopic.CreatedAt = DateTime.Now;
            newTopic = await ForumRepository.TopicsRepository.AddNewTopic(newTopic);
            return _mapper.Map<TopicDTO>(newTopic);
            
        }
        public async Task<TopicDTO> GetTopicByID(long topicDTO)
        {
            Topic topicByID = await ForumRepository.TopicsRepository.GetTopicByID(topicDTO);
            return _mapper.Map<TopicDTO>(topicByID);
        }
        public async Task<List<TopicDTO>> AllTopics()
        {
            List<Topic> topics = await ForumRepository.TopicsRepository.AllTopics();
            return _mapper.Map<List<TopicDTO>>(topics);
        }
        public async Task<bool> AddNewUserToTopic(int userID,long topicID)
        {
            return await ForumRepository.TopicsRepository.AddNewUserToTopic(userID, topicID);
        }

        public async Task<bool> RemoveUserFromTopic(int userID,long topicID)
        {
            return await ForumRepository.TopicsRepository.RemoveUserFromTopic(userID, topicID);
        }
        public async Task<bool> DeleteTopicByID(int deletedBy,long topicID)
        {
            return await ForumRepository.TopicsRepository.DeleteTopicByID(deletedBy, topicID);
        }
    }
}
