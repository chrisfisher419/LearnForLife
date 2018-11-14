using IdentitySample.Models;
using LFL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LFL.Models.ViewModels;

namespace LFL.Controllers
{
    public class EnrollmentController : Controller
    {
       
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SignUpList
        [HttpGet]
        public ActionResult AlreadyEnrolled()
        {
            return View();
        }

        public ActionResult Enroll(int? id)
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

            return View(course);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enroll(Course course, int? id)
        {
            course = db.Courses.Find(id);
            //Campaign campaign = db.Campaigns.Where()
            EnrollmentViewModel viewModel = new EnrollmentViewModel();
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();



            UserViewModel model = new UserViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                Email = profile.Email,
                //Activity = profile.Activity
            };
            Enrollment list = new Enrollment();
            list.UserID = profile.UserID;
            list.CourseID = course.CourseID;
            //list.DateSigned = System.DateTime.Now;


            foreach (var item in db.Enrollments)
                if (list.UserID == item.UserID && list.CourseID == item.CourseID)
                {
                    return RedirectToAction("AlreadyEnrolled", "Enrollment");
                }

            
            db.Enrollments.Add(list);
            db.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}