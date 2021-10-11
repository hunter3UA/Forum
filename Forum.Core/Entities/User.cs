﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Forum.Core.Entities
{
    [Index(propertyNames: new string[] { nameof(EmailAddress), nameof(NickName) }, IsUnique = true)]
    public class User
    {
        [Key]
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
        [JsonIgnore]
        public List<Topic> UserTopics { get; set; } = new List<Topic>();
        [Required]
        public bool IsEnabled { get; set; }
    }
}
