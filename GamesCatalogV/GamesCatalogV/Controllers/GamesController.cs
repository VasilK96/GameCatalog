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
using PagedList;


namespace GamesCatalogV.Controllers
{
    public class GamesController : Controller
    {
        private GameCatalogDbContext db = new GameCatalogDbContext();

		// GET: Games
		
		public ActionResult Index(int? page, string titleSearch, string sortOrder)
		{
			int pageNumber = page ?? 1;
			int pageSize = 10;
			IQueryable<Game> games = db.Games.AsQueryable();

			ViewBag.TitleSearch = titleSearch;
			if (!String.IsNullOrEmpty(titleSearch) && this.User.Identity.IsAuthenticated)
			{
				games = games.Where(x => x.Title.Contains(titleSearch));
			}

			ViewBag.CurrentSortParm = sortOrder;
			ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
			ViewBag.WriterSortParm = sortOrder == "rating_asc" ? "rating_desc" : "rating_asc";
			switch (sortOrder)
			{
				case "title_desc":
					games = games.OrderByDescending(x => x.Title);
					break;
				case "rating_asc":
					games = games.OrderBy(x => x.Rating);
					break;
				case "rating_desc":
					games = games.OrderByDescending(x => x.Rating);
					break;
				default:
					games = games.OrderBy(x => x.Title);
					break;
			}
			
			return View(games.ToPagedList(pageNumber, pageSize));
		}
		// GET: Games/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "RatingValue");
            ViewBag.GanreId = new SelectList(db.Gneres, "Id", "ganreValue");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseDate,RatingId,GanreId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "RatingValue", game.RatingId);
            ViewBag.GanreId = new SelectList(db.Gneres, "Id", "ganreValue", game.GanreId);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "RatingValue", game.RatingId);
            ViewBag.GanreId = new SelectList(db.Gneres, "Id", "ganreValue", game.GanreId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,RatingId,GanreId")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RatingId = new SelectList(db.Ratings, "Id", "RatingValue", game.RatingId);
            ViewBag.GanreId = new SelectList(db.Gneres, "Id", "ganreValue", game.GanreId);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
