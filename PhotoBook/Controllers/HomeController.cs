using PhotoBook.DBContexts;
using PhotoBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBook.Controllers
{
    public class HomeController : Controller
    {
        private PhotoBookContext db = new PhotoBookContext();

        public ActionResult Index()
        {
          

            return View();
        }
        public ActionResult Catalog()
        {
            var AllPublishersActive = db.Publishers.Where(x=>x.IsActive==true).OrderBy(x => x.State.Name);

            ViewBag.Message = "Your application description page.";

            return View(AllPublishersActive);
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