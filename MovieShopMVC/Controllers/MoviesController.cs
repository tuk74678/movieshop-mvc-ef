using System.Security.Claims;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;
        private readonly IPurchaseRepository purchaseRepository;

        public MoviesController(IMovieService _movieService, IPurchaseRepository _purchaseRepository)
        {
            movieService = _movieService;
            purchaseRepository = _purchaseRepository;
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
            var models = await movieService.GetMovieDetails(id); // await the async call
            return View(models);
        }
        [HttpPost]
        public async Task<IActionResult> Buy(int movieId, decimal price)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Check if the user already bought the movie
            var existingPurchase = await purchaseRepository.GetPurchaseByUserAndMovie(userId, movieId);
            if (existingPurchase != null)
            {
                TempData["Message"] = "You already own this movie.";
                return RedirectToAction("Details", new { id = movieId });
            }

            // Create new purchase
            var purchase = new Purchase
            {
                UserId = userId,
                MovieId = movieId,
                TotalPrice = price,
                PurchaseDateTime = DateTime.UtcNow,
                PurchaseNumber = Guid.NewGuid()     // Generates unique purchase number
            };

            await purchaseRepository.AddPurchaseAsync(purchase);

            TempData["Message"] = "Movie purchased successfully!";
            return RedirectToAction("Purchased", "User");
        }

    }
}
