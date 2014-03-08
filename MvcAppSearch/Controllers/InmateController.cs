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
using MvcAppSearch.Form;
using PagedList;
using PagedList.Mvc;

namespace MvcAppSearch.Controllers
{
    public class InmateController : Controller
    {
        private MvcAppSearch.Form.DRdb db = new MvcAppSearch.Form.DRdb();

        //
        // GET: /Inmate/

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page) //adds a page parameter, a current sort order parameter, and a current filter parameter to the method 
{
    ViewBag.CurrentSort = sortOrder;   // the view with the current sort order to keep the sort order the same while paging
           ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
           ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

           if (searchString != null)
           {
               page = 1;  //maintain the filter settings during paging, and it must be restored to the text box when the page is redisplayed
           }
           else
           {
               searchString = currentFilter;
           }

           ViewBag.CurrentFilter = searchString;  // provides the view with the current filter strin
            
            
            var inmates = from s in db.Inmates
                          select s;
           if (!String.IsNullOrEmpty(searchString))
           {
               inmates = inmates.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                      || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
           }
           switch (sortOrder)
           {
               case "Name_desc":
                   inmates = inmates.OrderByDescending(s => s.LastName);
                   break;
               case "Date":
                   inmates = inmates.OrderBy(s => s.ReportDate);
                   break;
               case "Date_desc":
                   inmates = inmates.OrderByDescending(s => s.ReportDate);
                   break;
               default: //Name ascending
                   inmates = inmates.OrderBy(s => s.LastName);
                   break;
           }
           int pageSize = 25;   // converts the inmate query to a single page of forms in a collection type that supports paging.
           int pageNumber = (page ?? 1);
           return View(inmates.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Inmate/Details/5
        public ActionResult Details(int id = 0)
        {
            Inmate inmate = db.Inmates.Find(id);
            if (inmate == null)
            {
                return HttpNotFound();
            }
            return View(inmate);
        }

        //
        // GET: /Inmate/Create

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Inmate/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Inmate inmate)
        {
            if (ModelState.IsValid)
            {
                db.Inmates.Add(inmate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inmate);
        }





        //
        // GET: /Inmate/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Inmate inmate = db.Inmates.Find(id);
            if (inmate == null)
            {
                return HttpNotFound();
            }
            return View(inmate);
        }

        //
        // POST: /Inmate/Edit/5

        [HttpPost]
        public ActionResult Edit(Inmate inmate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(inmate);
        }

        //
        // GET: /Inmate/Delete/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(int id = 0)
        {
            Inmate inmate = db.Inmates.Find(id);
            if (inmate == null)
            {
                return HttpNotFound();
            }
            return View(inmate);
        }

        //
        // POST: /Inmate/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, User")]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmate inmate = db.Inmates.Find(id);
            db.Inmates.Remove(inmate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}