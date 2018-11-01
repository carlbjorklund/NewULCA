using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewULCA;

namespace NewULCA.Controllers
{
    public class SchedulesController : Controller
    {
        private Entities db = new Entities();

        // GET: Schedules
        public ActionResult Index()
        {
            var schedules = db.Schedules.Include(s => s.Channels);
            return View(schedules.ToList());
        }

        // GET: Schedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedules schedules = db.Schedules.Find(id);
            if (schedules == null)
            {
                return HttpNotFound();
            }
            return View(schedules);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Name");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduledId,Image,ChannelId,AirDate,StarTime,EndTime,LengthTimeSpan,ShowId,Sorting")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Name", schedules.ChannelId);
            return View(schedules);
        }

        // GET: Schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedules schedules = db.Schedules.Find(id);
            if (schedules == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Name", schedules.ChannelId);
            return View(schedules);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduledId,Image,ChannelId,AirDate,StarTime,EndTime,LengthTimeSpan,ShowId,Sorting")] Schedules schedules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChannelId = new SelectList(db.Channels, "Id", "Name", schedules.ChannelId);
            return View(schedules);
        }

        // GET: Schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedules schedules = db.Schedules.Find(id);
            if (schedules == null)
            {
                return HttpNotFound();
            }
            return View(schedules);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schedules schedules = db.Schedules.Find(id);
            db.Schedules.Remove(schedules);
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
