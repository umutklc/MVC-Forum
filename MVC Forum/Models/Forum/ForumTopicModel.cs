using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCForum.Models.Forum;
using MVCForum.Models.Post;

namespace MVCForum.Models.Forum
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}
