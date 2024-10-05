using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProjectNight.Models;
namespace MyPortfolioProjectNight.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var value = context.About.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.About.Find(about.AboutID);
            value.Title = about.Title;
            value.Description = about.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}