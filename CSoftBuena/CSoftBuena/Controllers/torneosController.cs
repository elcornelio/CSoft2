using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSoftBuena;
using CSoftBuena.Models;

namespace CSoftBuena.Controllers
{
    public class torneosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: torneos
        public ActionResult Index()
        {
            return View(db.torneos.ToList());
        }

        // GET: torneos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            torneo torneo = db.torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // GET: torneos/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: torneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombreTorneo,fechaInicio,precioInscripcion,descripcion")] torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.torneos.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(torneo);
        }

        [Authorize]
        // GET: torneos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            torneo torneo = db.torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // POST: torneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombreTorneo,fechaInicio,precioInscripcion,descripcion")] torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(torneo);
        }

        [Authorize]
        // GET: torneos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            torneo torneo = db.torneos.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // POST: torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            torneo torneo = db.torneos.Find(id);
            db.torneos.Remove(torneo);
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
