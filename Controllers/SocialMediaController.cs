using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedya
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext();  
        public ActionResult Index()
        {
            return View(_dbContext.SocialMedias.ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.SocialMedias.Remove(_dbContext.SocialMedias.Find(id));   
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SocialMedia media)
        {
            _dbContext.SocialMedias.Add(media);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update( int id)
        {
            return View(_dbContext.SocialMedias.Find(id));
        }
        [HttpPost]
        public ActionResult Update(SocialMedia media)
        {
            var value = _dbContext.SocialMedias
                                   .Where(s => s.SocialMediaId == media.SocialMediaId)
                                   .FirstOrDefault();
            value.Name = media.Name;    
            value.Url = media.Url;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }  
    }
}