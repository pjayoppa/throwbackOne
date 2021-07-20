using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Throwback.Models;
using Throwback.ViewModels;
namespace Throwback.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                //'Name' is from models
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int movieid)
        {
            return Content("id=" + movieid);
        }

        public ActionResult Index(int? pagendx, string sortBy)
        {
            if (!pagendx.HasValue)
                pagendx = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pagendx, sortBy));
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }


             
    }
}