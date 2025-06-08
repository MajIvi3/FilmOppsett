using System.Diagnostics;
using FilmApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmApp.Controllers
{
    public class HomeController : Controller
    {

        private FilmContext context { get; set; } // Connection to database and it has a list of movies in its DB

        public HomeController(FilmContext ctx) { // This Constructure is where dependency injection allowes oure context to be passed to the controlle

            context = ctx;      

        }

        public IActionResult Index() // get all films from Database and send it to View
        {
            var alleFilmer = context.Film.OrderBy(f => f.Navn).ToList(); // Lag en querry som henter filmer fra FilmContex.cs
            return View(alleFilmer);  // Send it to view
        }

       
    }
}
