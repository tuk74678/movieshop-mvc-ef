using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    List<MovieCardModel>Top20Movies();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    MovieDetailsModel GetMovieDetails(int id);
}