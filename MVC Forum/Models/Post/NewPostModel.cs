
namespace MVCForum.Models.Post
{
    public class NewPostModel : PostBase
    {
        public string ForumName { get; set; }
        public int ForumId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
}
