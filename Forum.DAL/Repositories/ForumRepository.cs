
using Forum.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DAL.Repositories
{
    public class ForumRepository
    {
        public class UserRepository
        {

            public static async Task<List<User>> AllByTopicID(int topicId)
            {
                using(var db=new ForumDbContext())
                {
                    List<User> usersByTopic = await db.Users.Include(u=>u.UserTopics).SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).Where(u => u.Topic.TopicID == topicId).Select(u=>u.User).ToListAsync();
                    return usersByTopic;
                }
            }
            public static async Task<List<User>> AllByTopicName(string topicName)
            {
                using(var db=new ForumDbContext())
                {
                    List<User> userByTopic = await db.Users.Include(u=>u.UserTopics).SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).Where(u => u.Topic.TopicName == topicName).Select(u => u.User).ToListAsync();
                    return userByTopic;
                }
            }
            public static async Task<User> AddNewUser(User userToAdd)
            {
                using(var db=new ForumDbContext())
                {
                    await db.Users.AddAsync(userToAdd);
                    await db.SaveChangesAsync();
                    return userToAdd;
                }
            }
            public static async Task<User> GetUserByID(int userID)
            {
                using(var db=new ForumDbContext())
                {
                    User userToSearch = await db.Users.Include(u=>u.UserTopics).Where(u => u.UserID == userID && u.IsEnabled).FirstOrDefaultAsync();
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
            public static async Task<bool> DeleteByID(int userID)
            {
                using(var db=new ForumDbContext())
                {
                    User userToDelete = await db.Users.Where(u => u.UserID == userID && u.IsEnabled).FirstOrDefaultAsync();
                    if(userToDelete!=null)
                    {
                        db.Users.Remove(userToDelete);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            public static async Task<bool> DeleteByNickName(string nickName)
            {
                using (var db = new ForumDbContext())
                {
                    User userToDelete = await db.Users.Where(u => u.NickName==nickName && u.IsEnabled).FirstOrDefaultAsync();
                    if (userToDelete != null)
                    {
                        db.Users.Remove(userToDelete);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
