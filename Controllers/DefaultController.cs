using My_Portfolio_MVC.Models;
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
            
            return PartialView();
        }
        public PartialViewResult Experience()
        {
            return PartialView();
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
    }
}