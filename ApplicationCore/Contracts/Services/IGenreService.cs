using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IGenreService
{
    List<Genre> AllGenres();
}