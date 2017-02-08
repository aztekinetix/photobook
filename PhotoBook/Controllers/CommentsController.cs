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
    [Authorize]
    public class CommentsController : Controller
    {
        private PhotoBookContext db = new PhotoBookContext();

      
        [Authorize(Roles = "Admin")]
        // POST: Comments/Delete/5
        [ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id, int PublisherId)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("GetPublisherPublicProfile","Home",new { id=PublisherId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

      [AllowAnonymous]
      [ChildActionOnly]
        public ActionResult GetCommentsForPublisherId(int PublisherId)
        {
            IEnumerable<Comment> commentsList=db.Comments.Where(x => x.PublisherId == PublisherId).OrderBy(x=>x.CreatedOn);

            return View(commentsList);

        }

        [HttpPost]
        public ActionResult AddComment(FormCollection frmc)
        {
            var PublisherId = int.Parse(frmc["PublisherId"]);
            var CommentTextArea = frmc["CommentTextArea"];
            if ( CommentTextArea!= null)
            {
                db.Comments.Add(new Comment
                {
                    CreatedByUserName= User.Identity.Name,
                    CreatedOn=DateTime.Now,
                    PublisherId=PublisherId,
                    Text=CommentTextArea
                 });
                db.SaveChanges();
            }
            return RedirectToAction("GetPublisherPublicProfile", "Home", new { id = PublisherId });
        }

    }
}
