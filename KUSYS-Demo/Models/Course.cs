using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; } = null!;

        //public List<Student> CourseStudents { get; set; } = new List<Student>();
        public List<StudentCourse> StudentCourses { get; set; }
    }
}
