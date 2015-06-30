using EPRES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPRES.Controllers
{
    [Authorize]
    public class PharmacyController : Controller
    {
        // GET: Pharmacy
        public ActionResult Pharmacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pharmacy(PharmacyMaster U)
        {
            if (ModelState.IsValid)
            {
                using (EpresDbEntities dc = new EpresDbEntities())
                {
                    dc.PharmacyMasters.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Successfully saved pharmacy detail";
                }
            }
            return View(U);
        }
    }
}