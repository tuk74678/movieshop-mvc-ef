using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: MoviesController
        public ActionResult Index()
        {
            return View();
        }

    }
}
