using System;
using System.Web.Mvc;
using MVCezara.Models;

namespace MVCezara.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        private readonly MicroContext db = new MicroContext();

        public ActionResult Index()
        {
            ViewBag.posts = db.Posts;
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"];
            }
            return View();
        }

        public ActionResult Show(int id)
        {
            Post post = db.Posts.Find(id);
            if(TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"];
            }
            return View(post);
        }

        public ActionResult New()
        {
            Post post = new Post();
            return View();
        }

        [HttpPost]
        public ActionResult New(Post post)
        {
            post.UserPlaceholderId = 1;
            db.Posts.Add(post);
            db.SaveChanges();
            TempData["message"] = "Postarea a fost adaugata cu succes!";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Post post = db.Posts.Find(id);
            return View(post);
        }

        [HttpPut]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                var oldPost = db.Posts.Find(id);
                if (TryUpdateModel(oldPost))
                {
                    oldPost.Content = post.Content;
                    db.SaveChanges();
                }

                TempData["message"] = "Postarea a fost editata cu succes!";
                return RedirectToAction("Show", new { id = id });
            }
            catch (Exception e)
            {
                return RedirectToAction("Show", new { id = id });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}