using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_WebProject.Models;

namespace MVC_WebProject.Controllers
{
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();


        // GET: Movies
        public ActionResult Index(string MovieGenre, string SearchString, string Rting)
        {
            //----------------------------------------------------------------------------------------------
            // This section is for creating a genre list to fliter by on web page
            var GenreLst = new List<string>();              // Create empty list of string items
            var GenreQry = from d in db.Movies              // Create a SQL selection from the database
                           orderby d.Genre                  // Put genres in order
                           select d.Genre;                  // Select all genres
            GenreLst.AddRange(GenreQry.Distinct());         // Add Genres to list
            ViewBag.MovieGenre = new SelectList(GenreLst);  // Viewbag is populated for later use in IEnumerable
                                                            // when dropdown list is generated.
            
            //----------------------------------------------------------------------------------------------
                                                         
            // Looping through movies to search and find title if search string is provided
            // This method replaces the previous db.Movies.ToList() method since we want to
            // display a specific set of movies over all movies at once. 
            var movies = from m in db.Movies            // Selects all rows in movies
                         select m;
            
            //----------------------------------------------------------------------------------------------
            // This section is removing bad records if they are not correct per search/genre filters.

            // Slightly confused how this is operating since the same var is used for query and assignment.
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(t => t.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(g => g.Genre == MovieGenre);
            }
            if (!string.IsNullOrEmpty(Rting))
            {
                movies = movies.Where(r => r.Rating == Rting);
            }
            //return View(db.Movies.ToList());      // This is previous method that would return all rows
            return View(movies);                    // This returns specific movies obj with desired items.
        }

// Optional get method...
// This method has the search string following the /Movies/Index/SearchString
// The downfall here is the user must modify the URL to search which is a no-no.

//        // GET: Movies
//        public ActionResult Index(string SearchString)
//        {
//            var movies = from m in db.Movies
//                         select m;
//            if (!String.IsNullOrEmpty(SearchString))
//            {
//                movies = movies.Where(s => s.Title.Contains(SearchString));
//            }
//            //return View(db.Movies.ToList());
//            return View(movies);
//        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
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
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Rating,Price,Comments")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
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

            var Srch = "AvailableRatings";
        
            var RtgLst = new List<string>();
            var RtgQry = from d in db.FieldControls
                           where d.ControlName == Srch                     
                           select d.Control1;
            RtgLst.AddRange(RtgQry.First().Split(','));        
            ViewBag.RatingOpts = new SelectList(RtgLst);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Rating,Price,Comments")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
