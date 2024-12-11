using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortefolioDbContext _dbContext = new MyPortefolioDbContext();
        public ActionResult Index()
        {
            return View(_dbContext.Experiences.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Experiences.Remove(_dbContext.Experiences.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Experience experience)
        {
            _dbContext.Experiences.Add(experience);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Experiences.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Experience experience)
        {
            var value = _dbContext.Experiences
                                   .Where(s => s.ExperienceId == experience.ExperienceId)
                                   .FirstOrDefault();
            value.Title = experience.Title;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}