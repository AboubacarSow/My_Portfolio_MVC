using My_Portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        MyPortefolioDbContext _dbContext = new MyPortefolioDbContext();
        // GET: Contact
        public ActionResult Index()
        {
            return View(_dbContext.Contacts.ToList());
        }

        public ActionResult Delete (int id)
        {
            _dbContext.Contacts.Remove(_dbContext.Contacts.Find(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]  

        public ActionResult Create(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");
        } 
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_dbContext.Contacts.Find(id));
        }
        [HttpPost]  

        public ActionResult Update(Contact contact)
        {
            var value=_dbContext.Contacts.Where(x => x.ContactId == contact.ContactId).FirstOrDefault();
            value.Phone = contact.Phone;
            value.Email = contact.Email;
            _dbContext.SaveChanges();   
            return RedirectToAction("Index");
        }
    }
}