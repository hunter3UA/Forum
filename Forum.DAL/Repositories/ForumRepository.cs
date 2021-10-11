
using Forum.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DAL.Repositories
{
    public class ForumRepository
    {
        public class UsersRepository
        {
            
            public static async Task<List<User>> AllByTopicID(int topicId)
            {
                using (var db = new ForumDbContext())
                {
                    List<User> usersByTopic = await db.Users.Include(u => u.UserTopics).
                        SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).
                        Where(u => u.Topic.TopicID == topicId && u.User.IsEnabled == true).Select(u => u.User).ToListAsync();
                    return usersByTopic;
                }
                
            }
            public static async Task<List<User>> AllByTopicName(string topicName)
            {
                using (var db = new ForumDbContext())
                {
                    List<User> userByTopic = await db.Users.Include(u => u.UserTopics).
                        SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).
                        Where(u => u.Topic.TopicName == topicName && u.User.IsEnabled == true).Select(u => u.User).ToListAsync();
                    return userByTopic;
                }

            }
            public static async Task<User> AddNewUser(User userToAdd)
            {
                using(var db=new ForumDbContext())
                {
                    userToAdd.Role = await db.Roles.Where(r => r.RoleName == "User").FirstOrDefaultAsync();
                    await db.Users.AddAsync(userToAdd);
                    await db.SaveChangesAsync();
                    return userToAdd;
                }
            }
            

            public static async Task<User> GetUserByID(int userID)
            {
                using(var db=new ForumDbContext())
                {
               
                    User userToSearch = await db.Users.Include(u=>u.UserTopics).
                        FirstOrDefaultAsync(u => u.UserID == userID && u.IsEnabled);
                    return userToSearch;
                }
            }
            public static async Task<User> GetUserByNickName(string nickName)
            {
                using(var db=new ForumDbContext())
                {
                    User userToSearch = await db.Users.Include(u=>u.UserTopics).Where(u => u.NickName == nickName && u.IsEnabled).FirstOrDefaultAsync();
                    return userToSearch;
                }
            }
            public static async Task<User> DeleteByID(int userID)
            {
                using(var db=new ForumDbContext())
                {
                    User userToDelete = await db.Users.Where(u => u.UserID == userID && u.IsEnabled).FirstOrDefaultAsync();
                    if(userToDelete!=null)
                    {
                        userToDelete.IsEnabled = false;
                        await db.SaveChangesAsync();
                        return userToDelete;
                    }
                    return new User();
                }
            }           
            public static async Task<User> UpdateRole(int userIdToChange,string newRole)
            {
                using(var db=new ForumDbContext())
                {
                    User userToChangeRole = await db.Users.Where(u => u.UserID == userIdToChange && u.IsEnabled==true).FirstOrDefaultAsync();
                    if (userToChangeRole != null && userToChangeRole.Role.RoleName!=newRole)
                    {
                        userToChangeRole.Role = await db.Roles.Where(r => r.RoleName == newRole).FirstOrDefaultAsync();
                        await db.SaveChangesAsync();
                        
                    }
                    return userToChangeRole;
                }
            }

            public static async Task<bool> UpdateUser(User userToUpdate)
            {
                using(var db=new ForumDbContext())
                {
                    User userToChange = await db.Users.Where(u => u.UserID == userToUpdate.UserID).FirstOrDefaultAsync();
                    if (userToChange != null)
                    {
                        userToChange.NickName = userToUpdate.NickName;
                        userToChange.Status = userToUpdate.Status;
                        await db.SaveChangesAsync();
                        return true;

                    }
                    return false;
                }
            }

            public static async Task<List<User>> GetBannedUsers()
            {
                using(var db=new ForumDbContext())
                {
                    return await db.Users.Where(u => u.IsEnabled == false).ToListAsync();
                }
            }
        }

        public class TopicsRepository
        {
            public static async Task<Topic> AddNewTopic(Topic newTopic)
            {
                using(var db=new ForumDbContext())
                {
                    User createdByUser = await db.Users.Include(u=>u.Role)
                        .Where(u => u.UserID == newTopic.CreatedBy && u.IsEnabled)                 
                        .FirstOrDefaultAsync();
                    if (createdByUser != null)
                    {
                        newTopic.CreatedAt = DateTime.Now;
                        newTopic.Users.Add(createdByUser);
                        
                        await db.Topics.AddAsync(newTopic);
                        await db.SaveChangesAsync();                                          
                        return newTopic;
                    }
                    return new Topic();
                }
            }
            public static async Task<Topic> GetTopicByID(long topicID)
            {
                using(var db=new ForumDbContext())
                {
                    Topic topicToSearch = await db.Topics.Include(t=>t.Users).Where(t => t.TopicID == topicID).FirstOrDefaultAsync();
                    if (topicToSearch != null)
                    {
                        return topicToSearch;
                    }
                    return new Topic();
                }
            }
            public static async Task<List<Topic>> AllTopics()
            {
                using(var db=new ForumDbContext())
                {
                    List<Topic> allTopics = await db.Topics.Include(t=>t.Users).ToListAsync();
                    return allTopics;
                }
            }
            public static async Task<bool> DeleteTopicByID(int deletedBy,long topicID)
            {
                using(var db=new ForumDbContext())
                {
                    Topic topicToDelete = await db.Topics.
                        Where(t => t.TopicID == topicID && t.CreatedBy==deletedBy).FirstOrDefaultAsync();
                    if (topicToDelete != null)
                    {
                        db.Topics.Remove(topicToDelete);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            public static async Task<bool> AddNewUserToTopic(int userToAddId,long topicID)
            {
                using(var db=new ForumDbContext())
                {
                    User userToAdd = await db.Users.Where(u => u.UserID == userToAddId && u.IsEnabled).FirstOrDefaultAsync();
                    if (userToAdd == null) return false;
                    Topic topicWithNewUser = await db.Topics.Where(t => t.TopicID == topicID).FirstOrDefaultAsync();
                    if (topicWithNewUser == null) return false;
                    User isAlreadyExist = topicWithNewUser.Users.ToList()
                        .Where(u => u.UserID == userToAdd.UserID).FirstOrDefault();
                    if (isAlreadyExist == null)
                    {
                        topicWithNewUser.Users.Add(userToAdd);
                        userToAdd.UserTopics.Add(topicWithNewUser);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            } 
            public static async Task<bool> RemoveUserFromTopic(int userToRemoveID,long topicID)
            {
                using(var db=new ForumDbContext())
                {
                    User userToRemove = await db.Users.Where(u => u.UserID == userToRemoveID && u.IsEnabled).FirstOrDefaultAsync();
                    if (userToRemove == null) return false;
                    Topic topicWithNewUser = await db.Topics.Include(t=>t.Users).Where(t => t.TopicID == topicID).FirstOrDefaultAsync();
                    if (topicWithNewUser == null) return false;
                    User isAlreadyExist = topicWithNewUser.Users.ToList()
                        .Where(u => u.UserID == userToRemove.UserID).FirstOrDefault();
                    if (isAlreadyExist != null)
                    {
                        topicWithNewUser.Users.Remove(userToRemove);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }

        }
    }
}
