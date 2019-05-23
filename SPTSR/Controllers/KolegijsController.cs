using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SPTSR.Models;

namespace SPTSR.Controllers
{
    public class KolegijsController : Controller
    {
        private SeminarDBContext db = new SeminarDBContext();

        // GET: Kolegijs
        public ActionResult Index()
        {
            return View(db.Kolegiji.ToList());
        }

        // GET: Kolegijs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // GET: Kolegijs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kolegijs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Kolegiji.Add(kolegij);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kolegij);
        }

        // GET: Kolegijs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegijs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv")] Kolegij kolegij)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kolegij).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kolegij);
        }

        // GET: Kolegijs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kolegij kolegij = db.Kolegiji.Find(id);
            if (kolegij == null)
            {
                return HttpNotFound();
            }
            return View(kolegij);
        }

        // POST: Kolegijs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kolegij kolegij = db.Kolegiji.Find(id);
            db.Kolegiji.Remove(kolegij);
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
