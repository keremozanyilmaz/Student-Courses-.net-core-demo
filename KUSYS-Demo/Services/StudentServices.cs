using KUSYS_Demo.Context;
using KUSYS_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Services
{
    public class StudentServices :IStudentService
    {
        MVCContext db;
        public StudentServices(MVCContext _db)
        {
            db = _db;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            IEnumerable<Student> students = db.Students.Select(c => c).ToList();
            return (db.Students.Select(c => c).ToList());
        }

        public void DeleteStudent(int id)
        {
            Student student = db.Students.FirstOrDefault(c => c.StudentId == id);
            if (student != null)
            {
                db.Remove(student);
                db.SaveChanges();
            }
        }
        public void AddStudent(Student s)
        {
            db.StudentCourses.Include(x => x.Student);
            db.Students.Add(s);
            db.SaveChanges();
        }

        public List<Course> DropdownCoursList()
        {
            var values  = db.Courses.ToList();
            return values;
        }
    

        public Student GetStudentById(int id)
        {
            return db.Students.FirstOrDefault(c => c.StudentId == id);
        }

        public void UpdateStudent(Student s)
        {
            var student = db.Students.Find(s.StudentId);
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            student.Birthday = s.Birthday;
            db.SaveChanges();
        }

        public List<StudentModel> GetAll()
        {

            var results = (from sc in db.StudentCourses
                           join s in db.Students on sc.StudentId equals s.StudentId
                           join c in db.Courses on sc.CourseId equals c.CourseId
                           select new StudentModel { FirstName= s.FirstName,  LastName = s.LastName, CourseName=c.CourseName }).ToList();

            return results;

        }

       
    }
}
