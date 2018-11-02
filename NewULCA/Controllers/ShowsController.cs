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
    public class ShowsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Categories).Include(s => s.Schedules);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.ScheduledId = new SelectList(db.Schedules, "ScheduledId", "Image");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchowId,Title,Description,ShoImage,Length,CategoryId,ScheduledId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(shows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", shows.CategoryId);
            ViewBag.ScheduledId = new SelectList(db.Schedules, "ScheduledId", "Image", shows.ScheduledId);
            return View(shows);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", shows.CategoryId);
            ViewBag.ScheduledId = new SelectList(db.Schedules, "ScheduledId", "Image", shows.ScheduledId);
            return View(shows);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchowId,Title,Description,ShoImage,Length,CategoryId,ScheduledId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", shows.CategoryId);
            ViewBag.ScheduledId = new SelectList(db.Schedules, "ScheduledId", "Image", shows.ScheduledId);
            return View(shows);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shows shows = db.Shows.Find(id);
            db.Shows.Remove(shows);
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
