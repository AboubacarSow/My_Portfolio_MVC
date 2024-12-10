using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
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
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
            return PartialView();
        }
    }
}