using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCForum.Models.Post
{
    public abstract class PostBase
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
    }
}
