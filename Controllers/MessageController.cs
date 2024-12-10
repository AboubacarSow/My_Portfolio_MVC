using My_Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class MessageController : Controller
    {
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext();
        // GET: Message
        public ActionResult Index()
        {
            ViewBag.isRead=_dbContext.Messages.Where(m => m.IsRead==true).ToList().Count;
            ViewBag.isNotRead=_dbContext.Messages.Where(m => m.IsRead==false).ToList().Count;
            return View();
        }
        public ActionResult IsRead()
        {
            return View(_dbContext.Messages
                                  .Where (m=>m.IsRead==true)
                                  .ToList());
        } 
        public ActionResult IsNotRead()
        {
            return View(_dbContext.Messages
                                  .Where (m=>m.IsRead==false)
                                  .ToList());
        }
        public ActionResult Delete(int id)
        {
           // var message = _dbContext.Messages.Find(id);
            _dbContext.Messages.Remove(_dbContext.Messages
                                                  .Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SetAsRead(int id)
        {
            var message = _dbContext.Messages.Find(id);
            message.IsRead = true;
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}