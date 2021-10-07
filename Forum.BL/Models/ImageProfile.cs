using System.ComponentModel.DataAnnotations;

namespace Forum.BL.Models
{
    public class  ImageProfile
    {
        [Key]
        public int ImageProfileID { get; set; }
        [Required]
        public string ImageProfilePath { get; set; }
        [Required]
        public string ImageProfileName { get; set; }
    }
}
