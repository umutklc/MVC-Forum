using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVCForum.Models.Post
{
    public class PostIndexModel : PostBase
    {
        public string Title { get; set; }

        public int ForumId { get; set; }
        public string ForumName { get; set; }
           
        public IEnumerable<PostReplyModel> Replies { get; set; }


    }
}
