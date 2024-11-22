using My_Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        MyPortefolioDbContext dbContext = new MyPortefolioDbContext();

        // GET: Category
        public ActionResult Index()
        {
            var model = dbContext.Categories.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var value = dbContext.Categories.Find(id);

            if (value.Projects.Any(p => p.CategoryId.Equals(id)))
            {
               
                //TempData["ErrorMessage"] = "Bu kategory ait bir proje bulunmakta,dolaysıyla o silinemez";
                 var model = dbContext.Categories.ToList();
                 // return View("Index",model);
               return RedirectToAction("Index");
            }
            else
            {
                dbContext.Categories.Remove(value); 
                dbContext.SaveChanges();
                //TempData["SuccessMessage"] = "Işlem Başarılı";
                return RedirectToAction("Index");   
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = dbContext.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            Category value = dbContext.Categories.Find(category.CategoryId);
            value.Name = category.Name;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
