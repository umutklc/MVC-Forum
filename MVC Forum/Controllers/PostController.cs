using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVCForum.Data;
using MVCForum.Models.Post;
using MVCForum.Data.Models;


namespace MVCForum.Controllers
{
    public class PostController : Controller
    {
        private readonly IPost _postService;
        private readonly IForum _forumService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(IPost postService, IForum forumService, UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);
            var model = new PostIndexModel()
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                Created = post.Created,
                Content = post.Content,
                Replies = replies,
                ForumId = post.Forum.Id,
                ForumName = post.Forum.Title
            };

            return View(model);
        }

        public IActionResult Create(int id)
        {
            //id: forum id
            var forum = _forumService.GetById(id);

            var model = new NewPostModel()
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            var post = BuildPostReplies(model, user);
            await _postService.Add(post);

            // TODO: Implement User Rating Management

            return RedirectToAction("Index", "Post", new { id = post.Id });
        }

        private Post BuildPostReplies(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);

            return new Post()
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };

        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(reply => new PostReplyModel()
            {
                Id = reply.Id,
                AuthorId = reply.User.Id,
                AuthorRating = reply.User.Rating,
                AuthorName = reply.User.UserName,
                AuthorImageUrl = reply.User.ProfileImageUrl,
                Created = reply.Created,
                Content = reply.Content,
            });
        }
    }
}
