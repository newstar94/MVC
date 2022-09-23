using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Practice.Models;

namespace Practice.Controllers
{
    public class MoviesController : Controller
    {
        private Data db = new Data();
        int pageSize = 3;

        // GET: Movies
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            ViewBag.GenreID = new SelectList(db.Genres, "GenreId", "GenreName");
            var movies = db.Movies
                .Include(m => m.Genre)
                .OrderBy(m => m.MovieTitle);
            return View(movies.ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Index(int? GenreId, string MovieTitle, DateTime? Date, int? page)
        {
            int pageNumber = (page ?? 1);
            var movies = from m in db.Movies select m;
            int Id = GenreId.GetValueOrDefault();
            ViewBag.Id = Id;
            ViewBag.MovieTitle = MovieTitle;
            ViewBag.Date = Date;
            if (String.IsNullOrEmpty(MovieTitle))
            {
               movies = movies.Include(m => m.Genre)
                  .Where(m => m.GenreId == Id || Id == 0)
                  .Where(m => m.ReleaseDate == Date || !Date.HasValue);
            }
            else
            {
                movies = movies.Include(m => m.Genre)
                   .Where(m => m.GenreId == Id || Id == 0)
                   .Where(m=>m.MovieTitle.Contains(MovieTitle))
                   .Where(m => m.ReleaseDate == Date || !Date.HasValue);
            };
            movies = movies.OrderBy(m => m.MovieTitle);
            return View("_ListMovie", movies.ToPagedList(pageNumber, pageSize));
        }

        // GET: Movies/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieTitle,ReleaseDate,RunningTime,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieTitle,ReleaseDate,RunningTime,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
