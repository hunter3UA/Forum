using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Entities
{
    [Index(nameof(RoleName),IsUnique =true)]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
