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
        public PartialViewResult AdminLayoutSideBar()
        {
            GetUser();
            return PartialView();
        } 
        public PartialViewResult AdminLayoutNavBar()
        {
            GetUser();
            return PartialView();
        }

        private void GetUser()
        {
            var email = (string)Session["email"];
            var user = _dbContext.Admins.FirstOrDefault(p => p.Email == email);
            ViewBag.userName = user.Name + " " + user.LastName;
            ViewBag.image = user.ImageUrl;
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