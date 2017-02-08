using PhotoBook.DBContexts;
using PhotoBook.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            return View(AllPublishersActive);
        }

        public ActionResult GetPublisherPublicProfile(int id)
        {
            var publisher=db.Publishers.Find(id);

            return View(publisher);
        }
        [ChildActionOnly]
        public ActionResult GetCatalogImages(int id)
        {
            var publisherImagesList = db.PublisherPics.Where(x => x.PublisherId == id).OrderBy(x => x.UploadedOn).Include("Publisher");

            return PartialView(publisherImagesList);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ing. Daniel Ruiz";

            return View();
        }

        public ActionResult SearchPublisher(string SearchText)
        {
            var publisherList = db.Publishers.Where( x => x.Name.Contains(SearchText) && x.IsActive).OrderBy(x=>x.Name);

            return View("Catalog",publisherList);
        }
    }
}