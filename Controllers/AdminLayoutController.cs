﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Portfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
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
            return PartialView();
        } 
        public PartialViewResult AdminLayoutNavBar()
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