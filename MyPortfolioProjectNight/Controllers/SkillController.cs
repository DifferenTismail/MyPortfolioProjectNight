using MyPortfolioProjectNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
namespace MyPortfolioProjectNight.Controllers
{
    public class SkillController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult SkillList(int paged = 1)
        {
            var values = context.Skill.ToList().ToPagedList(paged, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View();
        }
    }
}