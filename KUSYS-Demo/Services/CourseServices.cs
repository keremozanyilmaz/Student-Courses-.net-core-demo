using KUSYS_Demo.Context;
using KUSYS_Demo.Models;

namespace KUSYS_Demo.Services
{
    public class CourseServices : ICourseServices
    {
        MVCContext db;
        public CourseServices(MVCContext _db)
        {
            db = _db;
        }
        public void DeleteCourse(int id)
        {
            Course course = db.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                db.Remove(course);
                db.SaveChanges();
            }
        }
        public void UpdateCourse(Course c)
        {
            var course = db.Courses.Find(c.CourseId);
            course.CourseName = c.CourseName;
            db.SaveChanges();
        }
        public void AddCourse(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = db.Courses.Select(c => c).ToList();
            return (db.Courses.Select(c => c).ToList());
        }

        public IEnumerable<Course> GetCourse(int id)
        {
            IEnumerable<Course> courses = db.Courses.Select(c => c).ToList();
            return db.Courses.Where(c => c.CourseId == id);

        }

        public Course TGetByID(int id)
        {
            return db.Courses.FirstOrDefault(c => c.CourseId == id);
        }
       
    }
}
