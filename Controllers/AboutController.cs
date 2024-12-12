using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortefolioDbContext _dbContext = new MyPortefolioDbContext();
        // GET: About
        public ActionResult Index()
        {
            return View(_dbContext.Abouts.ToList());
        }

        public ActionResult Delete(int id)
        {
            _dbContext.Abouts.Remove(_dbContext.Abouts
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
        public ActionResult Create(About about)
        {
            
            if (ModelState.IsValid)
            {
                if (about.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveLocation, about.ImageFile.FileName);
                    about.ImageFile.SaveAs(fileName);
                    about.ImageUrl = "/assets/" + about.ImageFile.FileName;
                }
                
                if (about.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveDirectory = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveDirectory, about.CvFile.FileName);
                    about.CvFile.SaveAs(fileName);
                    about.CvUrl = "/assets/" + about.CvFile.FileName;
                }
                _dbContext.Abouts.Add(about);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You missed somethings");
            return View(about);
        }  
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model= _dbContext.Abouts.Find(id);
            return View(model);
        }
        [HttpPost]  
        public ActionResult Update(About about)
        {
            var value= _dbContext.Abouts.Find(about.AboutId);
            if (ModelState.IsValid)
            {
                if (about.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveLocation, about.ImageFile.FileName);
                    about.ImageFile.SaveAs(fileName);
                    about.ImageUrl = "/assets/" + about.ImageFile.FileName;
                    value.ImageUrl = about.ImageUrl;
                }
                if (about.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveDirectory = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveDirectory, about.CvFile.FileName);
                    about.CvFile.SaveAs(fileName);
                    about.CvUrl = "/assets/" + about.CvFile.FileName;
                    value.CvUrl = about.CvUrl;
                }
                value.Title =about.Title;
                value.Description =about.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "You missed somethings");
            return View(about);
        
        }
    }
}