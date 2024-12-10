using My_Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortefolioDbContext _dbContext= new MyPortefolioDbContext();  
        // GET: AdminLayout
        public ActionResult Layout()
        {
            return View();
        }
        public PartialViewResult AdminLayoutHead()
        { 
            return PartialView();
        }
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }
        public ActionResult AdminLayoutSideBar()
        {
            return PartialView();
        }
 
        public ActionResult AdminLayoutNavBar()
        {

            return PartialView();   
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        } public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }
    }
}