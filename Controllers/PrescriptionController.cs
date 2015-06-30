using EPRES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPRES.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        public ActionResult Prescription()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prescription(PrescriptionMaster P)
        {
            if (ModelState.IsValid)
            {
                using (EpresDbEntities dc = new EpresDbEntities())
                {
                    dc.PrescriptionMasters.Add(P);
                    dc.SaveChanges();
                    ModelState.Clear();
                    P = null;
                    ViewBag.Message = "Successfully saved prescription detail";
                }
            }
            return View(P);
        }
    }
}