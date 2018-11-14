using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using LFL.Models;
using LFL.Models.ViewModels;

namespace LFL.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Course
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName, CourseInfo, SubjectID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName", course.SubjectID);
            return View(course);
        }

        public ActionResult CoursesBySubject(int? id)
        {
            Subject subject = db.Subjects.Find(id);
            int subjectID = subject.SubjectID;
            //Course course = db.Courses.Where(x => x.SubjectID == subject.SubjectID);
            Course course = new Course
            {
                SubjectID = subject.SubjectID
            };

            CourseViewModel viewModel = new CourseViewModel
            {
                CourseInfo = course.CourseInfo,
                CourseName = course.CourseName,

            };

            return View(viewModel);
        }
    }
}