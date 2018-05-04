using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinDeSession.Models;

namespace FinDeSession.Controllers
{
    public class TeacherController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        public Data data = new Data();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ajouter(Course c)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Data data = new Data();
            Course course = new Course
            {
                ID = data.count(),
                name = c.name,
                price = c.price,
                t_ID = c.t_ID
            };
            db.Courses.InsertOnSubmit(course);
            db.SubmitChanges();
            return Redirect("Index");
        }
        public ActionResult ViewCourse()
        {
            return View();
        }
        public ActionResult ViewStudent()
        {
            return View();
        }
        public ActionResult Remove()
        {
            int sid = Convert.ToInt32(Request.QueryString["s_id"]);
            int cid = Convert.ToInt32(Request.QueryString["c_id"]);
            Registration del = (from reg in db.Registrations
                      where reg.c_ID == cid && reg.s_ID == sid
                      select reg).Single<Registration>();
            db.Registrations.DeleteOnSubmit(del);
            db.SubmitChanges();
            return View();
        }
    }
}