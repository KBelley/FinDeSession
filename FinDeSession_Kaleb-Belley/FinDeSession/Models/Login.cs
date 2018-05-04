using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinDeSession.Models
{
    public class Login
    {
        private Data data = new Data();
        private DataClasses1DataContext db = new DataClasses1DataContext();
        public string user{ get; set; }
        public string pass{ get; set; }
        public Login(string username, string password)
        {
            this.user = username;
            this.pass = password;
        }
        public bool isValidTeacher()
        {
            foreach (FinDeSession.Teacher teach in db.Teachers)
            {
                if (teach.username == this.user && teach.password == this.pass)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isValid()
        {
            foreach(FinDeSession.Student stud in db.Students)
            {
                if(stud.username == this.user && stud.password == this.pass)
                {
                    return true;
                }
            }
            return false;
        }
        public bool isFirstLogin()
        {
            foreach (FinDeSession.Pergatory perg in db.Pergatories)
            {
                if (perg.username == this.user && perg.password == this.pass)
                {
                    return true;
                }
            }
            return false;
        }
        public FinDeSession.Models.Student currentStudent()
        {
            FinDeSession.Models.Student returnStudent = new Student();
            //var student = from stud in db.Students
            //          where stud.username == this.user && stud.password == this.pass
            //          select new Student { ID = stud.ID, fName = stud.fName, lName = stud.lName, email = stud.email, username = stud.username, password = stud.password };
            ////int id = from stud in db
            //    //returnStudent.ID = Convert.ToInt32(student.Take(1).ToString());
            //    returnStudent.fName = student.Skip(1).First().ToString();
            //    returnStudent.lName = student.Skip(2).First().ToString();
            //    returnStudent.email = student.Skip(3).First().ToString();
            //    returnStudent.username = student.Skip(4).First().ToString();
            //    returnStudent.password = student.Skip(5).First().ToString();

            returnStudent.ID = (from stud in db.Students
                          where stud.username == this.user && stud.password == this.pass
                          select stud.ID).Single();
            returnStudent.fName = (from stud in db.Students
                                   where stud.username == this.user && stud.password == this.pass
                                   select stud.fName).Single();
            returnStudent.lName = (from stud in db.Students
                                   where stud.username == this.user && stud.password == this.pass
                                   select stud.lName).Single();
            returnStudent.email = (from stud in db.Students
                                   where stud.username == this.user && stud.password == this.pass
                                   select stud.email).Single();
            returnStudent.username = (from stud in db.Students
                                      where stud.username == this.user && stud.password == this.pass
                                      select stud.username).Single();
            returnStudent.password = (from stud in db.Students
                                      where stud.username == this.user && stud.password == this.pass
                                      select stud.password).Single();
            return returnStudent;
        }
        public FinDeSession.Pergatory currentPergatory()
        {
            FinDeSession.Pergatory returnPergatory = new Pergatory();
            returnPergatory.ID = (from stud in db.Pergatories
                                where stud.username == this.user && stud.password == this.pass
                                select stud.ID).Single();
            returnPergatory.fName = (from stud in db.Pergatories
                                     where stud.username == this.user && stud.password == this.pass
                                   select stud.fName).Single();
            returnPergatory.lName = (from stud in db.Pergatories
                                     where stud.username == this.user && stud.password == this.pass
                                   select stud.lName).Single();
            returnPergatory.email = (from stud in db.Pergatories
                                     where stud.username == this.user && stud.password == this.pass
                                   select stud.email).Single();
            returnPergatory.username = (from stud in db.Pergatories
                                        where stud.username == this.user && stud.password == this.pass
                                      select stud.username).Single();
            returnPergatory.password = (from stud in db.Pergatories
                                        where stud.username == this.user && stud.password == this.pass
                                      select stud.password).Single();
            return returnPergatory;
        }
        public FinDeSession.Models.Teacher currentTeacher()
        {
            FinDeSession.Models.Teacher returnTeacher = new FinDeSession.Models.Teacher();
            returnTeacher.ID = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.ID).Single();
            returnTeacher.fName = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.fName).Single();
            returnTeacher.lName = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.lName).Single();
            returnTeacher.username = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.username).Single();
            returnTeacher.password = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.password).Single();
            returnTeacher.email = (from teach in db.Teachers
                                where teach.username == this.user && teach.password == this.pass
                                select teach.email).Single();
            return returnTeacher;
        }
    }
}