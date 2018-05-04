using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinDeSession.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int t_ID { get; set; }
    }
}