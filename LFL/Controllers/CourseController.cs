using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using LFL.Models;
using LFL.Models.DomainModels;
using LFL.Models.ViewModels;

namespace LFL.Controllers
{
    public class CourseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Course
       
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
        [Authorize(Roles = "Admin, Teacher")]
        public ActionResult Create([Bind(Include = "CourseID,CourseName, CourseInfo, SubjectID, CourseContent")] Course course)
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

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
            return View(course);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName, CourseInfo, CourseContent, SubjectID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
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

        // GET: Subjects/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
     
            if (course == null)
            {
                return HttpNotFound();
            }
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            if (profile == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enrolled = db.Enrollments.Where(x=>x.CourseID == id && x.UserID == profile.UserID).FirstOrDefault();
            if (enrolled == null)
            {
                return RedirectToAction("NotEnrolled", "Course");
            }

            UserViewModel model = new UserViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                Email = profile.Email
            };


            course.Lessons = new List<Lesson>();

            course.Lessons = db.Lessons.Where(x => x.CourseID == course.CourseID).ToList();
            


            return View(course);
        }

        public ActionResult NotEnrolled()
        {
            return View();
        }
    }
}