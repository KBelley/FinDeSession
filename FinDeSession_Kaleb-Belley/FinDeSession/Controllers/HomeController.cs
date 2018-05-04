using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinDeSession.Models;
using System.Diagnostics;
using System.Web.Routing;

namespace FinDeSession.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public Data data = new Data();
        public DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            //Student test = new Student { ID = 0, fName = "Kaleb", lName = "Belley" };
            //DataClasses1DataContext db = new DataClasses1DataContext();
            //db.Students.InsertOnSubmit(test);
            //db.SubmitChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Student(LoginInfo info)
        {
            if (ModelState.IsValid)
            {
                Login log = new Login(info.Username, info.Password);
                if (log.isFirstLogin())
                {
                    //Session["CurrentStudent"] = log.currentStudent();
                    Session["CurrentPerg"] = log.currentPergatory();
                    return Redirect("/Student/FirstLogin");
                }
                if (log.isValid())
                {
                    Session["Current"] = log.currentStudent();
                    return Redirect("/Student");
                }
            }
            return Redirect("Index");
        }
        [HttpPost]
        public ActionResult Admin(LoginInfo info)
        {
            if(ModelState.IsValid)
            {
                if (info.Username == "admin" && info.Password == "admin")
                {
                    return View(info);
                }
            }
            return Redirect("Index");
        }
        [HttpPost]
        public ActionResult Teacher(LoginInfo info)
        {
            if(ModelState.IsValid)
            {
                Login log = new Login(info.Username, info.Password);
                if (log.isValidTeacher())
                {
                    //Session["teacherID"] = from teacher in db.Teachers
                    //                       where teacher.username == info.Username && teacher.password == info.Password
                    //                       select teacher.ID;
                    //FinDeSession.Teacher tempTeacher = new FinDeSession.Teacher();
                    //tempTeacher = (Teacher)(from teach in db.Teachers
                    //          where teach.ID == (int)Session["teacherID"]
                    //          select teach);
                    //FinDeSession.Models.Teacher cTeacher = new Models.Teacher();
                    //cTeacher.ID = tempTeacher.ID;
                    //cTeacher.fName = tempTeacher.fName;
                    //cTeacher.lName = tempTeacher.lName;
                    //cTeacher.username = tempTeacher.username;
                    //cTeacher.password = tempTeacher.password;
                    //cTeacher.email = tempTeacher.email;
                    //Session["CurrentTeacher"] = cTeacher;
                    Session["CurrentTeacher"] = log.currentTeacher();
                    return Redirect("/Teacher");
                }
            }
            return Redirect("Index");
        }
    }
}