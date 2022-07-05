using KUSYS_Demo.Context;
using KUSYS_Demo.Models;
using KUSYS_Demo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        IStudentService iss;
        MVCContext db;
        public StudentController(IStudentService _iss, MVCContext _db)
        {
            iss = _iss;
            db = _db;
        }
        public IActionResult Index()
        {
            var values = iss.GetAllStudents();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            iss.DeleteStudent(id);
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            List<SelectListItem> list = iss.DropdownCoursList().Select(c=>new SelectListItem
            {
                Text =c.CourseName,
                Value =c.CourseId.ToString()
            }).ToList();
            ViewBag.CourseList = list;

            //var CourseList = c.Courses.Select(c => new { c.CourseId, c.CourseName }).ToList();

            // ViewBag.CourseList = CourseList;
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student s,int[] StudentCoursesCourseId)
        {
            iss.AddStudent(s);

            StudentCourse student = new StudentCourse();
            foreach (var item in StudentCoursesCourseId)
            {
                student.CourseId = item;
                student.StudentId = s.StudentId;
                db.StudentCourses.Add(student);
                db.SaveChanges();
            }
           

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
           
            var values = iss.GetStudentById(id);

            return PartialView("StudentDetails",values);
        }

        public IActionResult Edit(int id)
        {
            var values = iss.GetStudentById(id);
                return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Student s)
        {
            if(s.FirstName != null)
            {
               iss.UpdateStudent(s);
            }
            return RedirectToAction("Index");
        }
        public IActionResult GetAll()
        {
            var values = iss.GetAll();
            return View(values);
        }
    }
}
