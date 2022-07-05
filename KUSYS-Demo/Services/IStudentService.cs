using KUSYS_Demo.Models;

namespace KUSYS_Demo.Services
{
    public interface IStudentService
    {

        public IEnumerable<Student> GetAllStudents();
        public List<StudentModel> GetAll();
        public void DeleteStudent(int id);
        public void AddStudent(Student s);
        public List<Course> DropdownCoursList();
        public Student GetStudentById(int id);

        public void UpdateStudent(Student s);

    }
}
