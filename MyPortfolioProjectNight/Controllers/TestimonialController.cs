using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProjectNight.Models;
namespace MyPortfolioProjectNight.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.TestimonialID);
            value.Name = testimonial.Name;
            value.Title = testimonial.Title;
            value.Description = testimonial.Description;
            value.ImageUrl = testimonial.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}