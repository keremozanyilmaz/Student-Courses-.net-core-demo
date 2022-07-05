using KUSYS_Demo.Context;
using KUSYS_Demo.Models;
using KUSYS_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS_Demo.Controllers
{
    public class CourseController : Controller
    {
        ICourseServices ics;
        public CourseController(ICourseServices _ics)
        {
            ics = _ics;
        }

        public IActionResult Index()
        {
            return View(ics.GetAllCourses());
        }

        public IActionResult Delete(int id)
        {
            ics.DeleteCourse(id);
            return RedirectToAction("Index");


        }
        public IActionResult Edit(int id)
        {
            var values = ics.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Course c)
        {
            if (c.CourseName !=null)
            {
                ics.UpdateCourse(c);
            }
           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            //ics.AddCourse(c);
            return View();
        }

        [HttpPost]
        public ActionResult AddCourse(Course c)
        {
            ics.AddCourse(c);
            return RedirectToAction("Index");
        }
    }
}
