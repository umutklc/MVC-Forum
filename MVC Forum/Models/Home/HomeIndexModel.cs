using System.Collections.Generic;
using MVCForum.Models.Post;

namespace MVCForum.Models.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}
