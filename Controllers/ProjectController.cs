using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace My_Portfolio_MVC.Controllers
{
    public class ProjectController : Controller
    {
        MyPortefolioDbContext _dbContext=new MyPortefolioDbContext();   

        // GET: Project
        public ActionResult Index()
        {
            var model= _dbContext.Projects.ToList();    
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoryViewBag();
            return View();

        }

        private void CategoryViewBag()
        {
            var categories = (from c in _dbContext.Categories
                              select new SelectListItem
                              {
                                  Text = c.Name,
                                  Value = c.CategoryId.ToString(),
                              }).ToList();
            ViewBag.Categories = categories;
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                CategoryViewBag();
                ModelState.AddModelError("", "You do miss somethings");
                return View(project);
            }
          
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult Update( int id) 
        {
            Project project = _dbContext.Projects.Find(id);
            CategoryViewBag();
            return View(project);
        }
        [HttpPost]
        public ActionResult Update(Project project)
        {
            Project p = _dbContext.Projects.Find(project.ProjectId);
            if (!ModelState.IsValid)
            {
                CategoryViewBag();
                return View(project);
            }
            p.Name = project.Name;
            p.CategoryId = project.CategoryId;
            p.Description = project.Description;
            p.ImageUrl = project.ImageUrl;   
            p.GithubUrl = project.GithubUrl;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult Delete(int id)
        { 
           Project project= _dbContext.Projects.Find(id);
            _dbContext.Projects.Remove(project);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");   
        }

    }
}