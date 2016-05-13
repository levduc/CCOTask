using CCOTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCOTask.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllAppointment()
        {
            var model = from appointment in db.tblAppointments
                        orderby appointment.Date
                        select appointment;
            return View(model);
        }
        public ActionResult AllUser()
        {
            var model = from student in db.Users
                        select student;
            return View(model);
        }
    }
}