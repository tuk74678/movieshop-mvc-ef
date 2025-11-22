using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IGenreRepository genreRepository;
    public GenreService(IGenreRepository _genreRepository)
    {
        genreRepository = _genreRepository;
    }
    // get all genres
    public List<Genre> AllGenres()
    {
        return genreRepository.GetAllGenres().ToList();
    }
}