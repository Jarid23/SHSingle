using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }
            else
            {
                var viewModel = new StudentVM();
                viewModel.SetCourseItems(CourseRepository.GetAll());
                viewModel.SetMajorItems(MajorRepository.GetAll());
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int StudentId)
        {
            var student = StudentRepository.Get(StudentId);
            var studentVM = new StudentVM();
            studentVM.Student = student;
            studentVM.SetCourseItems(CourseRepository.GetAll());
            if (studentVM.Student.Courses != null)
            {
                studentVM.SelectedCourseIds = studentVM.Student.Courses.Select(c => c.CourseId).ToList();
            }
            studentVM.SetMajorItems(MajorRepository.GetAll());
            return View(studentVM);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            
            if (ModelState.IsValid)
            {
                
                var major = MajorRepository.Get(student.Major.MajorId);
                student.Major = major;
                StudentRepository.Edit(student);
            }
            else
            {
                var studentVM = new StudentVM();
                studentVM.Student = student;
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                return View(studentVM);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int StudentId)
        {
            var student = StudentRepository.Get(StudentId);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}