using My_Portfolio_MVC.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace My_Portfolio_MVC.Controllers
{
    public class LoginController : Controller
    {
        MyPortefolioDbContext  _dbContext = new MyPortefolioDbContext();    
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Index(Admin model)
        {
            var value =_dbContext.Admins.FirstOrDefault(a=>a.Email == model.Email && a.Sifre == model.Sifre && a.Sifre == model.Sifre );
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre hatalıdır");
                return View();
            }
            FormsAuthentication.SetAuthCookie(value.Email,false);
            Session["User name and surname"] = value.Name + " " + value.LastName;
            return RedirectToAction("Index","Project");
        }
    }
}