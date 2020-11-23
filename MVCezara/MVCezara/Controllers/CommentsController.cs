using System;
using System.Web.Mvc;
using MVCezara.Models;

namespace MVCezara.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MicroContext db = new MicroContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Comment comment)
        {
            comment.UserPlaceholderId = 1;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return Redirect("/Posts/Show/" + comment.PostId);
                }
                else
                {
                    return Redirect("/Posts/Show/" + comment.PostId);
                }
                
            }
            catch(Exception e)
            {
                return Redirect("/Posts/Show/" + comment.PostId);
            } 
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Redirect("/Posts/Show/" + comment.PostId);
        }

        public ActionResult Edit(int id)
        {
            Comment comment = db.Comments.Find(id);
            return View(comment);
        }

        [HttpPut]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                var oldComment = db.Comments.Find(id);
                if (TryUpdateModel(oldComment))
                {
                    oldComment.Content = comment.Content;
                    db.SaveChanges();
                }

                return Redirect("/Posts/Show/" + comment.PostId);
            }
            catch (Exception e)
            {
                return Redirect("/Posts/Show/" + comment.PostId);
            }
        }
    }
}