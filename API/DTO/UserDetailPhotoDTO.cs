namespace API.DTO
{
    public class UserDetailPhotoDTO
    {
        public int UserPhotoId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int IsMain { get; set; }
    }
}