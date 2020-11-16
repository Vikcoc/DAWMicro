using MVCezara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCezara.Controllers
{
    public class CommentsController : Controller
    {
        private MicroContext db = new MicroContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Comment comment)
        {
            comment.UserPlaceholderId = 1;
            db.Comments.Add(comment);
            db.SaveChanges();
            return Redirect("/Posts/Show/" + comment.PostId);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Redirect("/Posts/Show/" + comment.PostId);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.comment = db.Comments.Find(id);
            return View();
        }

        [HttpPut]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                Comment oldComment = db.Comments.Find(id);
                if(TryUpdateModel(oldComment))
                {
                    oldComment.Content = comment.Content;
                    db.SaveChanges();
                }

                return Redirect("/Posts/Show/" + comment.PostId);
            }
            catch(Exception e)
            {
                return Redirect("/Posts/Show/" + comment.PostId);
            }
        }
    }
}