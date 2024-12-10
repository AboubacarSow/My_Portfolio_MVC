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
            bool result = GetUser();
            if (!result)
            {
                return RedirectToAction("Redirect");
            }

            return PartialView();
        } 
        public ActionResult AdminLayoutNavBar()
        {
            bool result= GetUser();
            if (!result)
            {
                return RedirectToAction("Redirect");
            }
            
            return PartialView();
           
           
            
        }

        private bool GetUser()
        {
            var email = (string)Session["email"];
            if(string.IsNullOrEmpty(email) )
            {
                return false;
            }
            else
            {
                var user = _dbContext.Admins.Where(p => p.Email == email).FirstOrDefault();
                ViewBag.image = user.ImageUrl;
                ViewBag.userName =  user.Name + " " + user.LastName;
                return true;

            }
        }
        public ActionResult Redirect()
        {
            return RedirectToAction("Index", "Login");
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