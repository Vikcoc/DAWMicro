﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using MVCezara.Models;

namespace MVCezara.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Group
        private readonly MicroContext _context = new MicroContext();
        public ActionResult Index()
        {
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
            group.CreationDate = DateTime.UtcNow;
            _context.Groups.Add(group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show(int id)
        {
            ViewBag.Group = _context.Groups.Include("GroupMessages").FirstOrDefault(x => x.GroupId == id);
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Group = _context.Groups.Find(id);
            return View();
        }

        [HttpPut]
        public ActionResult Edit(Group group)
        {
            try
            {
                var dbGroup = _context.Groups.Find(group.GroupId);

                if (!TryUpdateModel(dbGroup))
                    return RedirectToAction("Edit", new { id = group.GroupId});

                dbGroup.GroupName = @group.GroupName;
                dbGroup.Description = @group.Description;

                _context.SaveChanges();
                return RedirectToAction("Show", new { id = group.GroupId });
            }
            catch (Exception)
            {
                return RedirectToAction("Show", new { id = group.GroupId });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var group = _context.Groups.Find(id);
            if(group != null)
                _context.Groups.Remove(group);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}