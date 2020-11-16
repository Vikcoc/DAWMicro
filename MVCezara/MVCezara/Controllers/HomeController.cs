using System.Web.Mvc;
using MVCezara.Models;

namespace MVCezara.Controllers
{
    public class HomeController : Controller
    {
        private readonly MicroContext smh = new MicroContext();

        public ActionResult Index()
        {
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