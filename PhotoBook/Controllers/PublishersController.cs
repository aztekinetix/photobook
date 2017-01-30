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
using PhotoBook.Utilities;
using System.Web.Configuration;
using System.IO;
using System.Text;

namespace PhotoBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PublishersController : Controller
    {
        private PhotoBookContext db = new PhotoBookContext();
        private IImageStorage imageStorage; // will be injected by Ninject
        
        public PublishersController(IImageStorage imgStorage)
        {
            this.imageStorage = imgStorage;
            
        } 

        // GET: Publishers
        public ActionResult Index()
        {
            var publishers = db.Publishers.Include(p => p.Country).Include(p => p.State);
            return View(publishers.ToList());
        }

        // GET: Publishers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name");
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublisherId,Name,IdNumber,IdImageUrl,Address,Telephone,Email,ProfileImageUrl,PricePerService,DescriptionService,IsActive,StateId,CountryId")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", publisher.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", publisher.StateId);
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", publisher.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", publisher.StateId);
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublisherId,Name,IdNumber,IdImageUrl,Address,Telephone,Email,ProfileImageUrl,PricePerService,DescriptionService,IsActive,StateId,CountryId")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", publisher.CountryId);
            ViewBag.StateId = new SelectList(db.States, "StateId", "Name", publisher.StateId);
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProfileImage(int id)
        {
            var publisher=db.Publishers.Find(id);
            return View(publisher);
        }

        [HttpPost]
        public ActionResult AddProfileImage(FormCollection frmc, HttpPostedFileBase profileImage)
        {
            //getting directory to save images from the web.config file
            string imagesDirectory = WebConfigurationManager.AppSettings["PublishersImagesDirectory"];
            string imagesDirectoryRooted = Server.MapPath("~"+imagesDirectory); //to save images the directory has to be passed rooted
            string id = frmc["PublisherId"];
            try
            {
                imageStorage.SaveImage(profileImage, imagesDirectoryRooted,id);
                var publisher = db.Publishers.Find(int.Parse(id));
                publisher.ProfileImageUrl = id + Path.GetExtension(profileImage.FileName);
                db.SaveChanges();
            }
            catch(Exception ex) {
                ModelState.AddModelError("ExceptionError",ex.Message);
                return View();
            }
            return RedirectToAction("Edit", "Publishers", new {id=id});
           
        }
       
        [ChildActionOnly] 
        public ActionResult GetCatalogImages(int id)
        {
            var publisherImagesList = db.PublisherPics.Where(x => x.PublisherId == id).OrderBy(x => x.UploadedOn).Include("Publisher");
            if (User.IsInRole("Admin"))
            {
                return PartialView("GetCatalogImagesAdmin", publisherImagesList);
            }
            return PartialView(publisherImagesList);
           
        }

      

        [HttpGet]
        public ActionResult AddCatalogImages(int id) {
           var publisher= db.Publishers.Find(id);
            ViewBag.fileNames = null;
            return View(publisher);
        }

        [HttpPost]
        public ActionResult AddCatalogImages(FormCollection frmc, IEnumerable<HttpPostedFileBase> files )
        {
            string id = frmc["PublisherId"];
            var publisher = db.Publishers.Find(int.Parse(id));
            string catalogDirectory = WebConfigurationManager.AppSettings["PublishersCatalogsDirectory"];
            string catalogsDirectoryWithId = Path.Combine(catalogDirectory,id);
            string catalogsDirectoryRooted = Server.MapPath("~" + catalogsDirectoryWithId); //to save images the directory has to be passed rooted
            StringBuilder sbUploadErrors = new StringBuilder();
            if (files != null)
            {
                var newFileName = "";
                foreach (HttpPostedFileBase file in files) { 
                    try
                    { 
                        newFileName = id + "_" + Path.GetRandomFileName();
                        imageStorage.SaveImage(file, catalogsDirectoryRooted, newFileName);
                        db.PublisherPics.Add(new PublisherPic
                        {
                            ImageUrl = newFileName+ Path.GetExtension(file.FileName),
                            Publisher=publisher,
                            PublisherId=int.Parse(id),
                            UploadedOn=DateTime.Now

                     });
                        db.SaveChanges();
                    }
                    //catch (InvalidOperationException ioex)
                    //{
                    //    // if the file name already exists in the database, ignore it
                    //}
                    catch(Exception e)
                    {
                        sbUploadErrors.Append(e.Message + " " + file.FileName);
                        Elmah.ErrorSignal.FromCurrentContext().Raise(e);  // logging error into Elmah


                    }

                }
                if (sbUploadErrors.Length > 0)
                {
                    ModelState.AddModelError("Exceptions",sbUploadErrors.ToString());
                    return View(publisher);
                }
                ViewBag.Message = "Image Uploaded successfully";
                // return RedirectToAction("AddCatalogImages", "Publishers", new { id = id });
                return View(publisher);
            }
            else
            {
                ModelState.AddModelError("Exceptions", "System has received no files");
                return View(publisher);
            }

          
            
        }


        public ActionResult RemoveCatalogImage(int? picId) {

            if (picId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublisherPic publisherPic = db.PublisherPics.Find(picId);
            if (publisherPic == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.PublisherPics.Remove(publisherPic);
                db.SaveChanges();
            }
            ViewBag.Message = "Deleted successfully";
            return RedirectToAction("AddCatalogImages", new { id = publisherPic.PublisherId });

        }

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
