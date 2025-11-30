using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetTop20MoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Task<Movie> GetMovieByIdAsync(int id);
    Task<PagedResult<Movie>> GetMoviesByGenrePagedAsync(int genreId, int pageNumber, int pageSize);

}