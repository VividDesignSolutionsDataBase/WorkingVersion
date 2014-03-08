using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MvcAppSearch.Filters;
using MvcAppSearch.Models;


namespace MvcAppSearch.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DR()
        {
            ViewBag.Title = "JSO";
            ViewBag.Message = "Disciplinary Review Forms";

            return View();
        }

        public ActionResult Form1a()
        {
            ViewBag.Message = "Initial Officer's Report.";

            return View();
        }

        public ActionResult Form1b()
        {
            ViewBag.Message = "1st Supervisor's Review.";

            return View();
        }

        public ActionResult Form2a()
        {
            ViewBag.Message = "1st Investigator's Report.";

            return View();
        }

        public ActionResult Form2b()
        {
            ViewBag.Message = "2nd Supervisor's Review.";

            return View();
        }

        public ActionResult Form3a()
        {
            ViewBag.Message = "DR Hearing Officer's Review";

            return View();
        }

        public ActionResult FSS9512310()
        {
            ViewBag.Message = "Section 951.23 (10)";

            return View();
        }


        
    }
}

