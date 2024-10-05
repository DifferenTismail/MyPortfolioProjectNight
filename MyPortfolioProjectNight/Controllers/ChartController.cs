using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolioProjectNight.Models;
namespace MyPortfolioProjectNight.Controllers
{
    public class ChartController : Controller
    {
        DbMyPortfolioNightEntities context = new DbMyPortfolioNightEntities();
        public ActionResult Index()
        {
            var values = context.Skill.ToList();
            return View(values);
        }
    }
}