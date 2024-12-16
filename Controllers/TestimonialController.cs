using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext();
        // GET: Testimonial
        public ActionResult Index()
        {
            return View(_dbContext.Testimonials.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }
        public ActionResult Create(Testimonial testimonial)
        {
            _dbContext.Testimonials.Add(testimonial);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Testimonials.Find(id));  
        } 

        public ActionResult Update(Testimonial testimonial)
        {
            var value=_dbContext.Testimonials.Find(testimonial.TestimonialId);
            value.FullName = testimonial.FullName;  
            value.Title= testimonial.Title;
            value.ImageUrl= testimonial.ImageUrl;   
            value.Comment= testimonial.Comment;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _dbContext.Testimonials.Remove(_dbContext.Testimonials.Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}