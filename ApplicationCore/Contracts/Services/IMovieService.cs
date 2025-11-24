using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    Task<List<MovieCardModel>> Top20MoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Task<MovieDetailsModel> GetMovieDetails(int id);
}