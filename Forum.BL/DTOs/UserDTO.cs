using Forum.Core.Entities;
using System;

namespace Forum.BL.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string NickName { get; set; }
        public string Status { get; set; }
        public string EmailAddress { get; set; }
        public DateTime RegistredAt { get; set; }
        public Role Role { get; set; }
        public Topic[] Topics { get; set; }
        public bool IsEnabled { get; set; }
    }
}
/*
    public int UserID { get; set; }
        [Required]
        [MaxLength(length: 100, ErrorMessage = "Size cannot exceed 100 characters")]
        public string NickName { get; set; }
        [MaxLength(length: 70, ErrorMessage = "Size cannot exceed 100 characters")]
        public string Status { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public DateTime RegistredAt { get; set; }
        public Topic[] UserTopics { get; set; }
        [Required]
        public bool IsEnabled { get; set; }*/