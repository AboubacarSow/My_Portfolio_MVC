using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class ExpertiseController : Controller
    {
        MyPortefolioDbContext _dbContext = new MyPortefolioDbContext();
        public ActionResult Index()
        {
            return View(_dbContext.Expertises.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Expertises.Remove(_dbContext.Expertises.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Expertise media)
        {
            _dbContext.Expertises.Add(media);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Expertises.Find(id));
        }
        [HttpPost]
        public ActionResult Update( Expertise expertise)
        {
            var value = _dbContext.Expertises.Find(expertise.ExpertiseId);
                                   
            value.Title = expertise.Title;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}