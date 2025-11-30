using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    Task<List<MovieCardModel>> Top20MoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Task<MovieDetailsModel> GetMovieDetailsAsync(int id);
    Task<PagedResult<Movie>> GetMoviesByGenrePagedAsync(int genreId, int pageNumber, int pageSize);

}