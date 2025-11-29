using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {   
        private readonly ICastService castService;
        public CastController(ICastService _castService)
        {
            castService = _castService;
        }
        
        // GET: CastController
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Details(int id)
        {
            var models = await castService.GetCastDetailsAsync(id); // await the async call
            return View(models); 
        }

    }
}
