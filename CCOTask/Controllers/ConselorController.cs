using CCOTask.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCOTask.Controllers
{
    [Authorize(Roles = "Conselor")]
    public class ConselorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Conselor
        public ActionResult Index()
        {
            return View();
        }
        //GET
        public ActionResult Unconfirm()
        {
            var model = from appointment in db.tblAppointments
                        orderby appointment.Date
                        where appointment.ConserlorEmail == null
                        select appointment;
            return View(model);
        }
        //POST
        public ActionResult Confirm(int id)
        {
            var model = db.tblAppointments.Find(id);
            var email = User.Identity.GetUserName();
            if (model != null)
            {
                model.ConserlorEmail = email;
                db.SaveChanges();
                return RedirectToAction("Index", "Conselor");
            }
            return View();
        }
        //
        public ActionResult Delete(int id)
        {
            var model = db.tblAppointments.Find(id);
            if (model != null)
            {
                db.tblAppointments.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Conselor");
            }
            return View();
        }
        //GET
        public ActionResult Confirmed()
        {
            var model = from appointment in db.tblAppointments
                        orderby appointment.Date
                        where appointment.ConserlorEmail != null 
                        select appointment;
            if (model != null)
            {
                return View(model);
            }
            return View();
        }
    }
}