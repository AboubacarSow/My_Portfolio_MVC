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
            return View(_dbContext.Messages
                                  .Where(m=>m.IsRead==false)
                                  .ToList());
        }

        //Next step Creating the modal to read message content
        public PartialViewResult MessageContent(int id)
        {
            return PartialView();
        }
        public ActionResult Delete(int id)
        {
           // var message = _dbContext.Messages.Find(id);
            _dbContext.Messages.Remove(_dbContext.Messages
                                                  .Find(id));
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}