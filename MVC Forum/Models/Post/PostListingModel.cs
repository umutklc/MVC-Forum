using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCForum.Models.Forum;

namespace MVCForum.Models.Post
{
    public class PostListingModel :  PostBase
    {
        public string Title { get; set; }
        public ForumListingModel Forum { get; set; }
        public int RepliesCount;
    }
}
