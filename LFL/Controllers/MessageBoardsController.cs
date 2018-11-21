using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using IdentitySample.Models;
using LFL.Models;
using LFL.Models.ViewModels;

namespace LFL.Controllers
{
    [Authorize]
    public class MessageBoardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MessageBoards
        public ActionResult Index()
        {
            return View(db.MessageBoards.ToList());
        }

        // GET: MessageBoards/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            messageBoard.Replies = db.Replies.Where(x=>x.TopicID == id).ToList();
            Replies reply = new Replies();
            reply.TopicID = messageBoard.TopicID;
            MessageBoardViewModel model = new MessageBoardViewModel
            {
                UserName = profile.UserName,
                TopicName = messageBoard.TopicName,
                TopicMessage = messageBoard.TopicMessage,
                TopicSubject = messageBoard.TopicSubject,
                Reply = reply,
                Replies = messageBoard.Replies
            };
           
            //var user = User.Identity.Name;
            //User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            //reply.UserID = profile.UserID;
            //reply.UserName = profile.UserName;
            //if (reply != null)
            //{
            //    SaveReply(reply);
            //}
            //Map to your view model
            //populate your replies object the user info, topic id

            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveReply([Bind(Include = "ReplyMessage,TopicID")] Replies reply)
        {
            //save the reply to the reply

            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            reply.UserID = profile.UserID;
            reply.UserName = profile.UserName;
            if (reply.ReplyMessage == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Replies.Add(reply);
            db.SaveChanges();
            return RedirectToAction("Details",new{id= reply.TopicID});

        }

        // GET: MessageBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageBoards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicID,TopicName,UserID,UserName,TopicSubject,TopicMessage")] MessageBoard messageBoard)
        {
            var user = User.Identity.Name;
            User profile = db.Users.Where(x => x.UserName == user).FirstOrDefault();
            if (ModelState.IsValid)
            {
                messageBoard.UserID = profile.UserID;
                messageBoard.UserName = profile.UserName;


                db.MessageBoards.Add(messageBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messageBoard);
        }

        // GET: MessageBoards/Edit/5
        [Authorize(Roles="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // POST: MessageBoards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TopicID,TopicName,UserID,UserName,TopicSubject,TopicMessage")] MessageBoard messageBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messageBoard);
        }

        // GET: MessageBoards/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            if (messageBoard == null)
            {
                return HttpNotFound();
            }
            return View(messageBoard);
        }

        // POST: MessageBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageBoard messageBoard = db.MessageBoards.Find(id);
            db.MessageBoards.Remove(messageBoard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
