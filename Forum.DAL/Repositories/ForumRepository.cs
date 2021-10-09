
using Forum.Core.Entities;
using Microsoft.EntityFrameworkCore;
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
                using(var db=new ForumDbContext())
                {
                    List<User> usersByTopic = await db.Users.Include(u=>u.UserTopics).
                        SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).
                        Where(u => u.Topic.TopicID == topicId && u.User.IsEnabled==true).Select(u=>u.User).ToListAsync();
                    return usersByTopic;
                }
            }
            public static async Task<List<User>> AllByTopicName(string topicName)
            {
                using(var db=new ForumDbContext())
                {
                    List<User> userByTopic = await db.Users.Include(u=>u.UserTopics).
                        SelectMany(u => u.UserTopics, (u, t) => new { User = u, Topic = t }).
                        Where(u => u.Topic.TopicName == topicName && u.User.IsEnabled==true).Select(u => u.User).ToListAsync();
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
                    User userToSearch = await db.Users.Where(u => u.UserID == userID && u.IsEnabled).FirstOrDefaultAsync();
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

        
    }
}
