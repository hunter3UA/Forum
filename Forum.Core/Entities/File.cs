using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Entities
{
    public class File
    {
        [Key]
        public long FileID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }
    }
}
