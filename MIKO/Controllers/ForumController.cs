﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MIKO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MIKO.Models.PostsModels;
using MIKO.Models.UserModels;
using MIKO.Models.CoctailModels;

namespace MIKO.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {

        ApplicationContext db;
        public ForumController(ApplicationContext context) { db = context; }

        [HttpGet]
        public IActionResult Home()
        {
            List<PostModel> posts = db.Posts.OrderByDescending(x => x.Id).ToList();
            return View(new HomeModel { Posts = posts, Id = 0});
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCreateModel model)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(new PostModel() { Title = model.Title, Text = model.Text, AuthorId = CurrentUserModel.CurrentUser.Id, AuthorLogin = CurrentUserModel.CurrentUser.Login });
                db.SaveChanges();
                return RedirectToAction("Home", "Forum");
            }
            return View();
            
        }

        public async Task<IActionResult> Profile(int id)
        {
            UserModel profileUser = db.Users.FirstOrDefault(i => i.Id == id);
            List<PostModel> profilePosts = (from item in db.Posts.ToList() where item.AuthorId == id select item).ToList();
            if (profileUser != null)
            {
                return View(new PostsUserModel { user = profileUser, posts = profilePosts});
            }
            return RedirectToAction("/Forum/Home");
        }

        public async Task<IActionResult> Post(int id)
        {
            PostModel postView =  db.Posts.FirstOrDefault(i => i.Id == id);
            if (postView != null)
            {
                return View(postView);
            }
            return RedirectToAction("/Forum/Home");
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Settings(UserProfileModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var user in db.Users.ToList())
                {
                    if (user.Login == CurrentUserModel.CurrentUser.Login && user.Password == CurrentUserModel.CurrentUser.Password)
                    {
                        user.Login = model.Login;
                        user.Password = model.Password;
                        user.Description = model.Description;
                        CurrentUserModel.CurrentUser = user;
                        db.SaveChanges();
                        return RedirectToAction("Home", "Forum");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult findUser() { return RedirectToAction("Home", "Find"); }

        [HttpPost]
        public IActionResult findUser(int id) { 
            if (ModelState.IsValid) { 
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                return Redirect("Profile/" + id);
            }
            return RedirectToAction("Home", "Forum");
        }

        [HttpGet]
        public IActionResult findPost() { return RedirectToAction("Home", "Forum"); }

        [HttpPost]
        public IActionResult findPost(int id)
        {
            if (ModelState.IsValid)
            {
                var user = db.Posts.FirstOrDefault(x => x.Id == id);
                return Redirect("Post/" + id);
            }
            return RedirectToAction("Home", "Forum");
        }
    }
}
