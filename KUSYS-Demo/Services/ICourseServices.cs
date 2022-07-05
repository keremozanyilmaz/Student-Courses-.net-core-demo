using KUSYS_Demo.Models;

namespace KUSYS_Demo.Services
{
    public interface ICourseServices
    {
        public IEnumerable<Course> GetAllCourses();
        public void DeleteCourse(int id);
        public void AddCourse(Course c);
        public void UpdateCourse(Course c);
        public IEnumerable<Course> GetCourse(int id);

        public Course TGetByID(int id);
    }
}
