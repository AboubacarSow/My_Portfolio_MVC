using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
       MyPortefolioDbContext _dbContext = new MyPortefolioDbContext();
        // GET: Banner
        public ActionResult Index()
        {
            return View(_dbContext.Banners
                                  .ToList());
        }
        public ActionResult Delete(int id)
        {
            _dbContext.Banners.Remove(_dbContext.Banners
                                                .Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Create(Banner banner)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Billginiz Kontrol Edin");
                return View(banner);
            }
            _dbContext.Banners.Add(banner);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Banners
                                  .Find(id) );
        }
        [HttpPost]  
        public ActionResult Update (Banner banner)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Billginiz Kontrol Edin");
                return View(banner);
            }
            var value = _dbContext.Banners.Where(b => b.BannerId == banner.BannerId)
                                        .FirstOrDefault();
            value.Title = banner.Title;
            value.Description = banner.Description;
            value.IsShown = banner.IsShown;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}