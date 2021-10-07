using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.BL.Models
{
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

        [Required]
        public bool IsEnabled { get; set; }
    }
}
