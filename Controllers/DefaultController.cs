﻿using My_Portfolio_MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext(); 
        // GET: Default
        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult Banner()
        {
            var model =_dbContext.Banners.Where(b=> (bool)b.IsShown).ToList();
            return PartialView(model);
        }
        public PartialViewResult Expertise()
        {
            
            return PartialView(_dbContext.Expertises.ToList());
        }
        public PartialViewResult Experience()
        {
            return PartialView(_dbContext.Experiences.ToList());
        }
        public PartialViewResult Project()
        {
            return PartialView(_dbContext.Projects.ToList());
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SendMessage(Message message)
        {
            DateTime date = DateTime.Now;
            message.DateTimeMessage = date;
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return PartialView();
        }
        public PartialViewResult About()
        {
            var value = _dbContext.Abouts.Where(a => a.AboutId == 1).FirstOrDefault();
            return PartialView(value);
        }
        public PartialViewResult Education()
        {
            return PartialView(_dbContext.Educations.ToList());
        }
        public PartialViewResult Contact()
        {
            return PartialView(_dbContext.Contacts.SingleOrDefault());
        }
        public PartialViewResult SocialMedia()
        {
            return PartialView(_dbContext.SocialMedias.ToList());
        }
        public PartialViewResult Testimonial()
        {
            return PartialView(_dbContext.Testimonials.ToList());
        }
       
    }
}