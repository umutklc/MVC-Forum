﻿using Microsoft.AspNetCore.Mvc;
using MVCForum.Data;
using MVCForum.Data.Models;
using MVCForum.Models.Forum;
using MVCForum.Models.Post;
using System.Linq;

namespace MVCForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _postService;
        public ForumController(IForum forumService, IPost postService)
        {
            _forumService = forumService;
            _postService = postService;
        }
        public IActionResult Index()
        {
            var forums = _forumService.GetAll().Select(forum => new ForumListingModel()
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description
            });

            var model = new ForumIndexModel()
            {
                ForumList = forums
            };
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = forum.Posts;
            var postlistings = posts.Select(p => new PostListingModel()
            {
                Id = p.Id,
                AuthorId = p.User.Id,
                AuthorName = p.User.UserName,
                AuthorRating = p.User.Rating,
                Title = p.Title,
                Created = p.Created,
                RepliesCount = p.Replies.Count(),
                Forum = BuildForumListing(p)
            });

            var model = new ForumTopicModel()
            {
                Posts = postlistings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel()
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl

            };
        }
    }
}