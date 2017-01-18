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
        public ActionResult Index()
        {
            //using (PhotoBookContext ctx = new PhotoBookContext())
            //{
            //    ctx.Publishers.Add(
            //        new Publisher
            //        {
            //            Name = "Daniel",
            //            IdNumber = "124udhurf",
            //            Address = "Oter 123213",
            //            Email = "dannie@coms.com",
            //            IdImageUrl = "Alpha",
            //            StateId = 1,
            //            Telephone = "57000123123"

            //        }
            //    );
            //    ctx.SaveChanges();
            //}

            return View();
        }
        public ActionResult Catalog()
        {
            ViewBag.Message = "Your application description page.";

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