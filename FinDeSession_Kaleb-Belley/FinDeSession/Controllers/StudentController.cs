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
    public class StudentController : Controller
    {
        public Data data = new Data();
        public DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: Student
        public ActionResult Index()
        {
            RouteData routeData = new RouteData();
            //RouteData.Values.Add("t_ID", "testete");
            return View();
        }
        public ActionResult FirstLogin()
        {
            return View();
        }
        public ActionResult InitializeLogin(LoginInfo info)
        {
            if (ModelState.IsValid)
            {
                int sCNT = (int)(from stud in db.StudIDs
                           select stud.Id).First();
                FinDeSession.Pergatory current = (FinDeSession.Pergatory)Session["CurrentPerg"];
                //FinDeSession.Models.Student current = (FinDeSession.Models.Student)Session["Current"];
                FinDeSession.Student transfer = new Student();
                //Debug.WriteLine(current.ID);
                //Debug.WriteLine(current.fName);
                //Debug.WriteLine(current.lName);
                //Debug.WriteLine(current.username);
                //Debug.WriteLine(current.password);
                var pTransfer = from perg in db.Pergatories
                                where perg.username == current.username && perg.password == current.password
                                select perg;
                Pergatory pergTransfer = new Pergatory();

                int currid = (from perg in db.Pergatories
                              where perg.username == current.username && perg.password == current.password
                              select perg.ID).Single();
                pergTransfer.ID = currid;
                transfer.ID = sCNT;
                transfer.fName = pergTransfer.fName = (from stud in db.Pergatories
                                                       where stud.username == current.username && stud.password == current.password
                                                       select stud.fName).Single();
                transfer.lName = pergTransfer.lName = (from stud in db.Pergatories
                                                       where stud.username == current.username && stud.password == current.password
                                                       select stud.lName).Single();
                transfer.email = pergTransfer.email = (from stud in db.Pergatories
                                                       where stud.username == current.username && stud.password == current.password
                                                       select stud.email).Single();
                pergTransfer.password = (from stud in db.Pergatories
                                         where stud.username == current.username && stud.password == current.password
                                         select stud.password).Single();
                pergTransfer.username = (from stud in db.Pergatories
                                         where stud.username == current.username && stud.password == current.password
                                         select stud.username).Single();

                db.Pergatories.Attach(pergTransfer);
                db.Pergatories.DeleteOnSubmit(pergTransfer);
                transfer.username = info.Username;
                transfer.password = info.Password;
                db.Students.InsertOnSubmit(transfer);
                StudID update = (from stud in db.StudIDs
                                select stud).First();
                StudID insertStud = new StudID();
                insertStud.Id = sCNT + 1;
                db.StudIDs.InsertOnSubmit(insertStud);
                db.StudIDs.DeleteOnSubmit(update);
                db.SubmitChanges();
                Login log = new Login(info.Username, info.Password);
                Session["CurrentStudent"] = log.currentStudent();
                return View("Index");
            }
            return Redirect("FirstLogin");
        }
        public ActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Student s)
        {
            if (ModelState.IsValid)
            {
                int pCNT = (int)(from perg in db.PergIDs
                                 select perg.Id).First();
                Pergatory insert = new Pergatory();
                insert.ID = pCNT;
                insert.fName = s.fName;
                insert.lName = s.lName;
                insert.email = s.email;
                insert.username = s.fName;
                insert.password = s.lName;
                //db.Pergatories.Attach((Pergatory)insert);
                db.Pergatories.InsertOnSubmit(insert);
                PergID update = (from perg in db.PergIDs
                                select perg).First();
                
                PergID insertPerg = new PergID();
                insertPerg.Id = pCNT + 1;
                db.PergIDs.InsertOnSubmit(insertPerg);
                db.PergIDs.DeleteOnSubmit(update);
                db.SubmitChanges();
            }
            return View("EmailStudent");
        }
        public ActionResult EmailStudent()
        {
            return View();
        }
        public ActionResult AvailableCourses()
        {

            return View();
        }
        public ActionResult RequestParticipation()
        {
            int c_id = Convert.ToInt32(Request.QueryString["c_id"]);
            FinDeSession.Models.Student curTest = (FinDeSession.Models.Student)Session["Current"];
            int teacherID = (int)(from cour in db.Courses
                            where cour.ID == c_id
                            select cour.t_ID).First();
            string teacherEmail = (from teacher in db.Teachers
                                  where teacher.ID == teacherID
                                  select teacher.email).Single();
            return View();
        }
        public ActionResult Logout()
        {
            Session["CurrentStudent"] = null;
            return Redirect("/Home");
        }
        public ActionResult ViewResources(int c_id)
        {
            return View();
        }
    }
}