﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinDeSession.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}