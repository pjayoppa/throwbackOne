using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Throwback.Models;
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
            //return View(movie);
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
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

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
             
    }
}