using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class ProfileController : Controller
    {
        MyPortefolioDbContext _dbContext=new MyPortefolioDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            string _email = (string)Session["email"];
            if (string.IsNullOrEmpty(_email))
            {
                return RedirectToAction("Index","Login");
            }
            var admin = _dbContext.Admins.FirstOrDefault(p => p.Email == _email);
            return View(admin);
        }
        [HttpPost]  
        public ActionResult Index(Admin model)
        {
            var admin= _dbContext.Admins.Find(model.AdminId);
            if (model.Sifre == admin.Sifre)
            {
                if(model.ImageFile != null)
                {
                    var currentDirectory= AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "assets\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName); 
                    admin.ImageUrl="/assets/" + model.ImageFile.FileName;
                    

                }
                admin.Name = model.Name;
                admin.LastName = model.LastName;    
                admin.Email = model.Email; 
                _dbContext.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index","Login");

            }
            ModelState.AddModelError("", "Girdiğiniz şifre hatalıdır");
            return View(model);
        }
    }
}