using PhotoBook.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoBook.Controllers
{
    public class CatalogController : Controller
    {
        PhotoBookContext db = new PhotoBookContext();
        // GET: Catalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCatalogImages(int id)
        {
            var publisherImagesList = db.PublisherPics.Where(x => x.PublisherId == id).OrderBy(x => x.UploadedOn).Include("Publisher");
           
            return PartialView(publisherImagesList);

        }
    }
}