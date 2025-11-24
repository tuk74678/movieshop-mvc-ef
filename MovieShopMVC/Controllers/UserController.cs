using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Favorites()
        {
            return View();
        }
        public ActionResult Purchased()
        {
            return View();
        }

    }
}
