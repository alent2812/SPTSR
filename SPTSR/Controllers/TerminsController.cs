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
    public class TerminsController : Controller
    {
        private SeminarDBContext db = new SeminarDBContext();

        // GET: Termins
        public ActionResult Index()
        {
            return View(db.Termini.ToList());
        }

        // GET: Termins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termini.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // GET: Termins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Termins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vrijeme,BrojIzlaganja")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Termini.Add(termin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termin);
        }

        // GET: Termins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termini.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // POST: Termins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vrijeme,BrojIzlaganja")] Termin termin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termin);
        }

        // GET: Termins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termin termin = db.Termini.Find(id);
            if (termin == null)
            {
                return HttpNotFound();
            }
            return View(termin);
        }

        // POST: Termins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termin termin = db.Termini.Find(id);
            db.Termini.Remove(termin);
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
