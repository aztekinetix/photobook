using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoBook.DBContexts;
using PhotoBook.Entities;

namespace PhotoBook.Controllers
{
    [Authorize(Roles ="Admin")]
    public class PublisherPicsController : Controller
    {
        private PhotoBookContext db = new PhotoBookContext();

        // GET: PublisherPics
        public ActionResult Index()
        {
            var publisherPics = db.PublisherPics.Include(p => p.Publisher);
            return View(publisherPics.ToList());
        }

        // GET: PublisherPics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherPic publisherPic = db.PublisherPics.Find(id);
            if (publisherPic == null)
            {
                return HttpNotFound();
            }
            return View(publisherPic);
        }

        // GET: PublisherPics/Create
        public ActionResult Create()
        {
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name");
            return View();
        }

        // POST: PublisherPics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublisherPicId,PublisherId,ImageUrl,UploadedOn,UploadedByUserId,Order")] PublisherPic publisherPic)
        {
            if (ModelState.IsValid)
            {
                db.PublisherPics.Add(publisherPic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", publisherPic.PublisherId);
            return View(publisherPic);
        }

        // GET: PublisherPics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherPic publisherPic = db.PublisherPics.Find(id);
            if (publisherPic == null)
            {
                return HttpNotFound();
            }
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", publisherPic.PublisherId);
            return View(publisherPic);
        }

        // POST: PublisherPics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublisherPicId,PublisherId,ImageUrl,UploadedOn,UploadedByUserId,Order")] PublisherPic publisherPic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisherPic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", publisherPic.PublisherId);
            return View(publisherPic);
        }

        // GET: PublisherPics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherPic publisherPic = db.PublisherPics.Find(id);
            if (publisherPic == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.PublisherPics.Remove(publisherPic);
                db.SaveChanges();
            }
            return RedirectToAction("AddCatalogImages","Publishers",new { id= publisherPic.PublisherId});
        }

        //// POST: PublisherPics/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    PublisherPic publisherPic = db.PublisherPics.Find(id);
        //    db.PublisherPics.Remove(publisherPic);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
