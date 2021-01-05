using GenericRepoExample.Interfaces;
using GenericRepoExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepoExample.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(IUnitOfWork unit)
        {
            unitOfWork = unit;
        }
        public IUnitOfWork unitOfWork { get; set; }
        //
        // GET: /Course/

        public ViewResult Index()
        {
            var courses = unitOfWork.generic_repo_course.Get(includeProperties: "Student");
            return View(courses.ToList());
        }

        //
        // GET: /Course/Details/5

        public ViewResult Details(int id)
        {
            Course course = unitOfWork.generic_repo_course.GetByID(id);
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(include: "CourseID,Title,Credits,StudentID")]
         Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.generic_repo_course.insert(course);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.StudentID);
            return View(course);
        }

        public ActionResult Edit(int id)
        {
            Course course = unitOfWork.generic_repo_course.GetByID(id);
            PopulateDepartmentsDropDownList(course.StudentID);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(include:  "course_id,course_name,StudentID")]
         Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.generic_repo_course.Update(course);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateDepartmentsDropDownList(course.StudentID);
            return View(course);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = unitOfWork.generic_repo_student.Get(
                orderBy: q => q.OrderBy(d => d.name));
            ViewBag.DepartmentID = new SelectList(departmentsQuery, "student_id", "name", selectedDepartment);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id)
        {
            Course course = unitOfWork.generic_repo_course.GetByID(id);
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = unitOfWork.generic_repo_course.GetByID(id);
            unitOfWork.generic_repo_course.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
