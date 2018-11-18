using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            EnrollmentViewModel viewModel = new EnrollmentViewModel();
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            if (profile == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            UserViewModel model = new UserViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                Email = profile.Email,
                //Activity = profile.Activity
            };
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Enrollment list = db.Enrollments.Where(x => x.CourseID == course.CourseID).FirstOrDefault();
            //list.UserID = profile.UserID;
            //list.CourseID = id ?? default(int);
            //list.CourseID = course.CourseID;
            //list.DateSigned = System.DateTime.Now;
            foreach (var item in db.Enrollments)
            {
                if (item.UserID == profile.UserID && item.CourseID == course.CourseID)
                {
                    return View(course);
                }
  
            }

            return RedirectToAction("NotEnrolled", "Course");
        }

        public ActionResult NotEnrolled()
        {
            return View();
        }
    }
}