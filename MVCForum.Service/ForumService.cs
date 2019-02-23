using Microsoft.EntityFrameworkCore;
using MVC_Forum.Data;
using MVCForum.Data;
using MVCForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MVCForum.Service
{
    class ForumService : IForum
    {
        private readonly ApplicationDbContext _dbContext;
        public ForumService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(Forum forum)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int forumId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _dbContext.Forums.Include(forum=>forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {
            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}
