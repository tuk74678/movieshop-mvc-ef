using System.Diagnostics;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService movieService;
    private readonly IGenreService genreService;
    public HomeController(IMovieService _movieService, IGenreService _genreService)
    {
        movieService = _movieService;
        genreService = _genreService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var topMovies = await movieService.Top20MoviesAsync();
        return View(topMovies);
    }
    [HttpGet]
    public IActionResult Genre()
    {
        var genres = genreService.AllGenres();
        return View(genres);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}