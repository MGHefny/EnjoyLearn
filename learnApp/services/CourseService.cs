using learnApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//service function for Courses
namespace learnApp.services
{
    public interface ICourseService
    {
        int Create(course_t course);
    }
    public class CourseService : ICourseService
    {
        private readonly enjoy_learn_DBEntities db;
        public CourseService()
        {
            db = new enjoy_learn_DBEntities();
        }
        public int Create(course_t course)
        {
            course.creation_date = DateTime.Now;

            db.course_t.Add(course);
            return db.SaveChanges();
        }
    }
}