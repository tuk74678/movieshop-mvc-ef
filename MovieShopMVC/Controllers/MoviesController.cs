using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }
        // GET: MoviesController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ByGenre(int genreId)
        {
            // Call the service (which calls repository)
            var movies = await movieService.GetMoviesByGenreAsync(genreId);

            // Pass data to the view
            return View(movies);
        }
        [HttpGet]
        public async Task<IActionResult> MovieDetails(int id)
        {
            var model = await movieService.GetMovieDetailsAsync(id); // await the async call
            return View(model); // now it's the correct type
        }

    }
}
