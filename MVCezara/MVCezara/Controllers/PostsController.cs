﻿using MVCezara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCezara.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        private MicroContext db = new MicroContext();
        public ActionResult Index()
        {
            ViewBag.posts = db.Posts;
            return View();
        }

        public ActionResult Show(int id)
        {
            ViewBag.post = db.Posts.Find(id);
            return View();
        } 

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            post.UserPlaceholderId = 1;
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.post = db.Posts.Find(id);
            return View();
        } 

        [HttpPut]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                Post oldPost = db.Posts.Find(id);
                if (TryUpdateModel(oldPost))
                {
                    oldPost.Content = post.Content;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}