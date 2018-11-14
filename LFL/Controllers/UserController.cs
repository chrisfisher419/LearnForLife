using IdentitySample.Models;
using LFL.Models;
using LFL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LFL.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profile
        public ActionResult Details()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Campaign");
            }

            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();

            UserViewModel model = new UserViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                Email = profile.Email
                //Activity = profile.Activity
            };
            return View(model);

        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();

            UserViewModel model = new UserViewModel
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                PhoneNumber = profile.PhoneNumber,
                Email = profile.Email
                //Activity = profile.Activity
            };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( /*[Bind(*/ /*Include = "UserID, FirstName,LastName, Address, ZipCode")]*/
            UserViewModel model)
        {
            //var user = User.Identity.Name;
            //UserProfileInfo profile = db.UserProfileInfo.Where(x => x.Username == user).FirstOrDefault();
            //ProfileViewModel model = new ProfileViewModel
            //{
            //    Address = profile.Address,
            //    ZipCode = profile.ZipCode,
            //    FirstName = profile.FirstName,
            //    LastName = profile.LastName
            //};
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();

            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.PhoneNumber = model.PhoneNumber;
            profile.Email = model.Email;
            //profile.Activity = model.Activity;




            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details");


        }
    }
}