using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GamesCatalogV.Context;
using GamesCatalogV.Entities;

namespace GamesCatalogV.Controllers
{
    public class GanresController : Controller
    {
        private GameCatalogDbContext db = new GameCatalogDbContext();

        // GET: Ganres
        public ActionResult Index()
        {
            return View(db.Gneres.ToList());
        }

        // GET: Ganres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ganre ganre = db.Gneres.Find(id);
            if (ganre == null)
            {
                return HttpNotFound();
            }
            return View(ganre);
        }

        // GET: Ganres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ganres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ganreValue,Description")] Ganre ganre)
        {
            if (ModelState.IsValid)
            {
                db.Gneres.Add(ganre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ganre);
        }

        // GET: Ganres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ganre ganre = db.Gneres.Find(id);
            if (ganre == null)
            {
                return HttpNotFound();
            }
            return View(ganre);
        }

        // POST: Ganres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ganreValue,Description")] Ganre ganre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ganre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ganre);
        }

        // GET: Ganres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ganre ganre = db.Gneres.Find(id);
            if (ganre == null)
            {
                return HttpNotFound();
            }
            return View(ganre);
        }

        // POST: Ganres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ganre ganre = db.Gneres.Find(id);
            db.Gneres.Remove(ganre);
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
