using System.ComponentModel.DataAnnotations;

namespace Forum.BL.Models
{
    public class File
    {
        public long FileID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
