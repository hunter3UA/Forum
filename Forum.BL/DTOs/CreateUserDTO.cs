using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BL.DTOs
{
    public class CreateUserDTO
    {
        public string NickName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }
}
/*
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
 
 
 
 
 
 */