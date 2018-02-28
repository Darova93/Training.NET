using Academia_1.Models;
using Academia_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academia_1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(movies);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult MoviesReleaseByDate(int year, int month)
        {
            string smonth;
            switch (month)
            {
                case 01:
                    smonth = "January";
                    break;
                case 02:
                    smonth = "February";
                    break;
                case 03:
                    smonth = "March";
                    break;
                case 04:
                    smonth = "April";
                    break;
                case 05:
                    smonth = "May";
                    break;
                case 06:
                    smonth = "June";
                    break;
                case 07:
                    smonth = "July";
                    break;
                case 08:
                    smonth = "August";
                    break;
                case 09:
                    smonth = "September";
                    break;
                case 10:
                    smonth = "October";
                    break;
                case 11:
                    smonth = "November";
                    break;
                case 12:
                    smonth = "December";
                    break;
                default:
                    smonth = "Invalid month";
                    break;
            }
            return Content($"Year: {year} | Month: {smonth}");
        }

        [Route("movies/{id:int}")]
        public ActionResult GetMovieById(int id)
        {
            Movie movie = GetMovies().SingleOrDefault(i => i.Id == id);

            if (movie == null)
            {
                return new HttpNotFoundResult("Movie not found");
                //throw new HttpException(404, "Movie not found");
            }

            //int movieid = movie.Id;
            //string name = movie.Name;
            //return Content($"ID: {movieid} | Name: {name}");

            return View(movie);
        }

        [Route("movies/genre")]
        public ActionResult MovieForm()
        {
            var movies = GetMovies();

            var result = new MovieFormViewModel();
            result.Movie = movies.FirstOrDefault();
            result.Genre = GetGenre();

            return View(result);
        }

        private List<Movie> GetMovies()
        {
            var movies = new List<Movie>()
            {
                new Movie{Id = 1, Name = "Shrek"},
                new Movie{Id = 2, Name = "Die Hard"},
                new Movie{Id = 3, Name = "Cantinflas"}
            };

            return movies;
        }

        private List<Genre> GetGenre()
        {
            var genre = new List<Genre>()
            {
                new Genre{Id = 1, Name = "Romantic"},
                new Genre{Id = 2, Name = "Comedy"},
                new Genre{Id = 3, Name = "Mexicanas"}
            };

            return genre;
        }
    }
}