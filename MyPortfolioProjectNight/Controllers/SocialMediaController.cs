﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProjectNight.Models;
namespace MyPortfolioProjectNight.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SocialMediaList()
        {
            var values = context.SocialMedia.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            context.SocialMedia.Add(socialMedia);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = context.SocialMedia.Find(socialMedia.SocialMediaID);
            value.Title = socialMedia.Title;
            value.Url = socialMedia.Url;
            value.Icon = socialMedia.Icon;
            value.Active = socialMedia.Active;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedia.Find(id);

            if (value != null)
            {
                value.Active = false; 
                context.SaveChanges();
            }

            return RedirectToAction("SocialMediaList");
        }
    }
}