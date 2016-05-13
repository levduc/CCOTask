using CCOTask.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCOTask.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET: 
        public ActionResult CreateAppointment()
        {
            return View();
        }
        //POST 
        [HttpPost]
        public ActionResult CreateAppointment(Appointments tempAppointment)
        {
            if(ModelState.IsValid)
            {
                var email = User.Identity.GetUserName();
                tempAppointment.StudentEmail = email;
                db.tblAppointments.Add(tempAppointment);
                db.SaveChanges();
                return RedirectToAction("Index", "Student");
            }
            return View();
        }
        public ActionResult Confirmed()
        {
            var email = User.Identity.GetUserName();
            var model = from appointment in db.tblAppointments
                        orderby appointment.Date
                        where appointment.ConserlorEmail != null && appointment.StudentEmail == email
                        select appointment;
            if(model != null)
            {
                return View(model);
            }
            return View();
        }
    }
}