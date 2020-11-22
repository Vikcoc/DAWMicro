using System;
using System.Linq;
using System.Web.Mvc;
using MVCezara.Models;

namespace MVCezara.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Group
        private readonly MicroContext _context = new MicroContext();

        public ActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Group group)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("New");
            @group.CreationDate = DateTime.UtcNow;
            _context.Groups.Add(@group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            var group = _context.Groups.Include("GroupMessages").FirstOrDefault(x => x.GroupId == id);
            return View(group);
        }

        public ActionResult Edit(int id)
        {
            var group = _context.Groups.Find(id);
            return View(group);
        }

        [HttpPut]
        public ActionResult Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dbGroup = _context.Groups.Find(group.GroupId);

                    if (!TryUpdateModel(dbGroup))
                        return RedirectToAction("Edit", new {id = group.GroupId});

                    if (dbGroup != null)
                    {
                        dbGroup.GroupName = @group.GroupName;
                        dbGroup.Description = @group.Description;
                    }

                    _context.SaveChanges();
                    return RedirectToAction("Show", new {id = group.GroupId});
                }
                catch (Exception)
                {
                    return RedirectToAction("Show", new {id = group.GroupId});
                }
            }
            return RedirectToAction("Show", new { id = group.GroupId });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var group = _context.Groups.Find(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                TempData["message"] = "Grupul cu numele: " + group.GroupName + " a fost sters";
            }            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}