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
    public class SeminarsController : Controller
    {
        private SeminarDBContext db = new SeminarDBContext();

        // GET: Seminars
        public ActionResult Index()
        {
            var seminari = db.Seminari.Include(s => s.Kolegiji).Include(s => s.Teme).Include(s => s.Termini);
            return View(seminari.ToList());
        }

        // GET: Seminars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        // GET: Seminars/Create
        public ActionResult Create()
        {
            ViewBag.KolegijId = new SelectList(db.Kolegiji, "Id", "Naziv");
            ViewBag.TemaId = new SelectList(db.Teme, "Id", "Naslov");
            ViewBag.TerminId = new SelectList(db.Termini, "Id", "Id");
            ViewBag.KorisnikId = new SelectList(db.KorisnikKolegiji, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: Seminars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TemaId,TerminId,MaxClanovi,RokPrijave,Clan1,Clan2,Clan3,Clan4,Clan5,KorisnikId,KolegijId")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Seminari.Add(seminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KolegijId = new SelectList(db.Kolegiji, "Id", "Naziv", seminar.KolegijId);
            ViewBag.TemaId = new SelectList(db.Teme, "Id", "Naslov", seminar.TemaId);
            ViewBag.TerminId = new SelectList(db.Termini, "Id", "Id", seminar.TerminId);
            return View(seminar);
        }

        // GET: Seminars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            ViewBag.KolegijId = new SelectList(db.Kolegiji, "Id", "Naziv", seminar.KolegijId);
            ViewBag.TemaId = new SelectList(db.Teme, "Id", "Naslov", seminar.TemaId);
            ViewBag.TerminId = new SelectList(db.Termini, "Id", "Id", seminar.TerminId);
            return View(seminar);
        }

        // POST: Seminars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TemaId,TerminId,MaxClanovi,RokPrijave,Clan1,Clan2,Clan3,Clan4,Clan5,KorisnikId,KolegijId")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KolegijId = new SelectList(db.Kolegiji, "Id", "Naziv", seminar.KolegijId);
            ViewBag.TemaId = new SelectList(db.Teme, "Id", "Naslov", seminar.TemaId);
            ViewBag.TerminId = new SelectList(db.Termini, "Id", "Id", seminar.TerminId);
            return View(seminar);
        }

        // GET: Seminars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminari.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        // POST: Seminars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminar seminar = db.Seminari.Find(id);
            db.Seminari.Remove(seminar);
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
