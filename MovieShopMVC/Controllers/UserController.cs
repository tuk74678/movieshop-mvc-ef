using System.Security.Claims;
using ApplicationCore.Contracts.Services;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Favorites()
        {
            return View();
        }
        public async Task<IActionResult> Purchased()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var purchasedMovies = await _userService.GetPurchasedMovies(userId);
            return View(purchasedMovies);
        }
        
        public async Task<IActionResult> PurchaseDetail(int movieId)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var purchases = await _userService.GetPurchasedMovies(userId);
            var purchase = purchases.FirstOrDefault(p => p.MovieId == movieId);

            if (purchase == null)
                return NotFound();

            return View(purchase);
        }
        public ActionResult UserInfo()
        {
            return View();
        }
    }
}
