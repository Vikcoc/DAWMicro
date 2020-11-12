using MVCezara.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCezara.Controllers
{
    public class HomeController : Controller
    {
        private readonly MicroContext smh = new MicroContext();
        public ActionResult Index()
        {
            Debug.WriteLine(smh.UserPlaceholders.FirstOrDefault().FirstName);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}