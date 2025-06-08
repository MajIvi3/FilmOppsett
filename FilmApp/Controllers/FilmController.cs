using FilmApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace FilmApp.Controllers
{
    public class FilmController : Controller
    {

        private FilmContext Context { get; set; }


        public FilmController(FilmContext ctx){ 
            
            Context = ctx;
        }

        [HttpGet]
        public IActionResult LeggTil() //Snakker med leggTil 
        {
            ViewBag.Action = "Legg til en ny Film";
            return View("Endre", new FilmModel()); // lager ny objekt
        }

        [HttpGet]
        public IActionResult Endre(int id) // henter id av filmen vi ønsker å slette
        {
            ViewBag.Action = "Endre film";
            var film = Context.Film.Find(id); // hent fil ved hjelp av ID(primær nøkkel)
            return View(film);
        }

        [HttpPost]
        public IActionResult EndreTxt(FilmModel filmInn)
        {
            if (ModelState.IsValid)
            {
                if (filmInn.Id == 0)
                {
                    Context.Film.Add(filmInn);
                }
                else
                {
                    Context.Film.Update(filmInn);
                }

                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // show Validation errors
                ViewBag.Action = (filmInn.Id == 0) ? "Add" : "Edit";
                return View("Endre", filmInn);
            }   

        }
        [HttpGet]
        public IActionResult Slett(int id)
        {
            ViewBag.Action = "Slett film";
            var film = Context.Film.Find(id); 
            return View(film);
        }

        [HttpPost]
        public IActionResult Slett(FilmModel film)
        {
            Context.Film.Remove(film);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
