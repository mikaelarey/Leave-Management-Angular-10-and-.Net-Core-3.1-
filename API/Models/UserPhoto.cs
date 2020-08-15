using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class UserPhoto
    {
        public int UserPhotoId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int IsMain { get; set; }

        [ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }
        public UserDetail UserDetail { get; set; } 
    }
}