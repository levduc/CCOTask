using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCOTask.Models
{
    public class Appointments
    {
        public int id { get; set; }
        public string StudentEmail { get; set; }
        public DateTime Date  { get; set; }
        public string Note { get; set; }
        public string ConserlorEmail { get; set; }
    }
}