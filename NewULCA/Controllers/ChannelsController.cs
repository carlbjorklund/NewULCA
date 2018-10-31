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
    public class ChannelsController : Controller
    {
        private Entities db = new Entities();

        // GET: Channels
        public ActionResult Index()
        {
            return View(db.Channels.ToList());
        }

        // GET: Channels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channels channels = db.Channels.Find(id);
            if (channels == null)
            {
                return HttpNotFound();
            }
            return View(channels);
        }

        // GET: Channels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Title,ChaImage")] Channels channels)
        {
            if (ModelState.IsValid)
            {
                db.Channels.Add(channels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(channels);
        }

        // GET: Channels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channels channels = db.Channels.Find(id);
            if (channels == null)
            {
                return HttpNotFound();
            }
            return View(channels);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Title,ChaImage")] Channels channels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(channels);
        }

        // GET: Channels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channels channels = db.Channels.Find(id);
            if (channels == null)
            {
                return HttpNotFound();
            }
            return View(channels);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Channels channels = db.Channels.Find(id);
            db.Channels.Remove(channels);
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
