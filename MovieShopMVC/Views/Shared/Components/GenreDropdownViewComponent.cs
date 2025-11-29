using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Views.Shared.Components.GenreDropDown;

//  View Component for displaying all genres in the dropdown
public class GenreDropdownViewComponent : ViewComponent
{
    private readonly IGenreService _genreService;

    public GenreDropdownViewComponent(IGenreService genreService)
    {
        _genreService = genreService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Fetch genres from the service
        var genres = _genreService.AllGenres() ?? new List<Genre>();
        return View(genres);
    }
}