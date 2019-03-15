using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCForum.Data;
using MVCForum.Data.Models;
using MVCForum.Models;
using MVCForum.Models.Forum;
using MVCForum.Models.Home;
using MVCForum.Models.Post;

namespace MVCForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        public HomeController(IPost postService, IForum forumService)
        {
            _postService = postService;
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);
            var posts = latestPosts.Select(post => new PostListingModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.User.UserName,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Created = post.Created,
                Forum = GetForumListingForPost(post)
            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };

        }

        private ForumListingModel GetForumListingForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl = forum.ImageUrl
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
