using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
