using MVCForum.Data;
using MVCForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MVCForum.Service
{
    public class PostService : IPost
    {
        private readonly ApplicationDbContext _dbContext;

        public PostService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string content)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int n)
        {
            return GetAll().OrderByDescending(post => post.Created).Take(n);
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Replies)
                .ThenInclude(r => r.User)
                .Include(p => p.Forum);

        }

        public Post GetById(int id)
        {
            return _dbContext.Posts.Where(p => p.Id == id)
                .Include(p => p.User)
                .Include(p => p.Replies)
                .ThenInclude(r => r.User)
                .Include(p => p.Forum)
                .First();
        }

        public IEnumerable<Post> GetFilteredPost()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetFilteredPost(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostByForum(int id)
        {
            var posts = _dbContext.Forums.First(f => f.Id == id).Posts;
            return posts;
        }
    }
}
