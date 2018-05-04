using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace FinDeSession.Models
{
    public class Data
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        public int count()
        {
            var cnt = (from test in db.Courses
             select test.ID).Count();
            return cnt;
        }
        public List<Course> allCourses()
        {
            List<Course> result = new List<Course>();

            var select = from item in db.Courses
                        select item;

            foreach (var item in select)
            {
                Course row = new Models.Course();
                row.ID = item.ID;
                row.name = item.name;
                row.price = (double)item.price;
                row.t_ID = (int)item.t_ID;
                result.Add(row);
            }

            return result;
        }
        public List<Course> teacherCourses(int tID)
        {
            List<Course> courses = new List<Course>();
            var select = from cour in db.Courses
                         where cour.t_ID == tID
                         select cour;
            foreach(FinDeSession.Course item in select)
            {
                FinDeSession.Models.Course temp = new Course();
                temp.ID = item.ID;
                temp.name = item.name;
                temp.price = (double)item.price;
                temp.t_ID = tID;
                courses.Add(temp);
            }
            return courses;
        }
        public List<Student> classStudents(int cID, int tID)
        {
            List<int> students = new List<int>();
            List<Student> result = new List<Student>();
            var select = from stud in db.Students
                         join regist in db.Registrations on stud.ID equals regist.s_ID
                         where regist.c_ID == cID && regist.t_ID == tID
                         select stud;
                foreach (FinDeSession.Student item in select)
                {
                    Student temp = new Student();
                    temp.ID = item.ID;
                    temp.fName = item.fName;
                    temp.lName = item.lName;
                    temp.email = item.email;
                    result.Add(temp);
                }
            return result;
        }
        public List<Course> studentCourses(int tID)
        {
            List<Course> courses = new List<Course>();
            List<int> lstCID = new List<int>();
            var query = from reg in db.Registrations
                      where reg.t_ID == tID
                      select reg.c_ID;
            foreach(int element in query)
            {
                FinDeSession.Course temp = (FinDeSession.Course)(from cour in db.Courses
                                        where cour.ID == element
                                        select cour).Single();
                FinDeSession.Models.Course cTemp = new FinDeSession.Models.Course();
                cTemp.ID = temp.ID;
                cTemp.name = temp.name;
                cTemp.price = (double)temp.price;
                cTemp.t_ID = (int)temp.t_ID;
                courses.Add(cTemp);
            }
            return courses;
        }
        public List<Course> notStudentCourses(int tID)
        {
            List<Course> courses = new List<Course>();
            var query = from cour in db.Courses
                        select cour;

            foreach (FinDeSession.Course element in query)
            {
                if((from reg in db.Registrations where reg.c_ID ==  element.ID && reg.t_ID == tID select reg) != null)
                {
                    FinDeSession.Course tCourse = (FinDeSession.Course)(from cour in db.Courses
                                  where cour.ID == element.ID
                                  select cour).Single();
                    FinDeSession.Models.Course cTemp = new Course();
                    cTemp.ID = tCourse.ID;
                    cTemp.name = tCourse.name;
                    cTemp.price = (double)tCourse.price;
                    cTemp.t_ID = (int)tCourse.t_ID;
                    courses.Add(cTemp);
                }
            }
            return courses;
        }
        public List<Resource> courseResources(int cID)
        {
            List<Resource> lstRes = (from res in db.Resources
                                     where res.c_id == cID
                                     select res).ToList();
            return lstRes;
        }
    }
}