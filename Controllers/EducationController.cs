using My_Portfolio_MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext();
        // GET: Education
        public ActionResult Index()
        {
          var model = _dbContext.Educations.ToList() ?? new List<Education>();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create ()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(Education education)
        { 
            _dbContext.Educations.Add(education);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 
        [HttpGet]
        public ActionResult Update (int id)
        { 
            return View(_dbContext.Educations.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Education model)
        { 
           Education education = _dbContext.Educations.Find(model.EducationId);
            education.SchoolName = model.SchoolName;
            education.Description = model.Description;
            education.Department = model.Department;    
            education.Degree = model.Degree;    
            education.StartDate = model.StartDate;
            model.EndDate = model.EndDate;
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}