using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageVar.Models;

namespace ManageVar.Controllers
{
    public class ClearerController : Controller
    {
        //
        // GET: /AppManag/

        public ActionResult Index()
        {
            var lad = new ListAppData();
            lad.LoadAll();
            return View(lad);
        }

        [HttpPost]
        public JsonResult DeleteItem(string TheKey, int Source)
        {
            try
            {
                var lad = new ListAppData();
                lad.DeleteItem(TheKey, (SourceData)Source);
                return Json(new { ok = true, message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
            
        }
    }
}
