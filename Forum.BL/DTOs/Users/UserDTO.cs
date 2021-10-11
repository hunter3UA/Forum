using Forum.Core.Entities;
using System;

namespace Forum.BL.DTOs.Users
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string NickName { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RegistredAt { get; set; }
        public Role Role { get; set; }
        public Topic[] UserTopics { get; set; }
        public bool IsEnabled { get; set; }
    }
}
